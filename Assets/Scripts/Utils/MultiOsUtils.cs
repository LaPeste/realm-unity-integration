using System;
using UnityEngine;

namespace Platformer.Utils
{
    public static class MultiOsUtils
    {
        public static string GetWritableOsLocation()
        {
            var path = string.Empty;

#if UNITY_ANDROID && !UNITY_EDITOR
            var appId = Application.identifier;
            path = $"/data/data/{appId}/files";

            try
            {
                IntPtr obj_context = AndroidJNI.FindClass("android/content/ContextWrapper");
                IntPtr method_getFilesDir = AndroidJNIHelper.GetMethodID(obj_context, "getFilesDir", "()Ljava/io/File;");
     
                using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        IntPtr file = AndroidJNI.CallObjectMethod(obj_Activity.GetRawObject(), method_getFilesDir, new jvalue[0]);
                        IntPtr obj_file = AndroidJNI.FindClass("java/io/File");
                        IntPtr method_getAbsolutePath = AndroidJNIHelper.GetMethodID(obj_file, "getAbsolutePath", "()Ljava/lang/String;");  
                                   
                        path = AndroidJNI.CallStringMethod(file, method_getAbsolutePath, new jvalue[0]);                    
     
                        if (path is null)
                        {
                            Debug.LogWarning("Using fallback path");
                            path = $"/data/data/{appId}/files";
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Debug.Log(e.ToString());
            }
#else
            path = Application.persistentDataPath;
#endif

#if DEBUG
            Debug.Log("Got internal path: " + path);
#endif

            return path;
        }
    }
}