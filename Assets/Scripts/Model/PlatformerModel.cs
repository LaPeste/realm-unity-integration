using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;
using Realms;
using System.IO;
using System;

namespace Platformer.Model
{
    /// <summary>
    /// The main model containing needed data to implement a platformer style 
    /// game. This class should only contain data, and methods that operate 
    /// on the data. It is initialised with data in the GameController class.
    /// </summary>
    [System.Serializable]
    public class PlatformerModel
    {
        /// <summary>
        /// The virtual camera in the scene.
        /// </summary>
        public Cinemachine.CinemachineVirtualCamera virtualCamera;

        /// <summary>
        /// The main component which controls the player sprite, controlled 
        /// by the user.
        /// </summary>
        public PlayerController player;

        /// <summary>
        /// The spawn point in the scene.
        /// </summary>
        public Transform spawnPoint;

        /// <summary>
        /// A global jump modifier applied to all initial jump velocities.
        /// </summary>
        public float jumpModifier = 1.5f;

        /// <summary>
        /// A global jump modifier applied to slow down an active jump when 
        /// the user releases the jump input.
        /// </summary>
        public float jumpDeceleration = 0.5f;

        public IList<LevelModel> levels;

        private LevelModel _level;
        public LevelModel Level => _level;

        //private readonly RealmConfigurationBase _realmConfig;
        //public RealmConfigurationBase RealmConfiguration => _realmConfig;


        // Start is called before the first frame update
        public PlatformerModel()
        {
            //Debug.LogWarning($"LocalAppData ==> {Application.persistentDataPath}");
            //var realmPath = Path.Combine(Application.persistentDataPath, "realm_test_db");

            //#if (UNITY_STANDALONE && UNITY_EDITOR)
            //            _realmConfig.ConfigWithPath("realm_test_db");
            //#elif UNITY_ANDROID
            //            _realmConfig.ConfigWithPath("/storage/emulated/0/Android/data/com.Realm.RealmPluginForUnity/realm_test_db");
            //#elif UNITY_IOS
            //            _realmConfig.ConfigWithPath("realm_test_db");
            //#endif
            //_realmConfig = new RealmConfiguration(realmPath)
            //{
            //    ShouldDeleteIfMigrationNeeded = true
            //};


            //_realmConfig = new InMemoryConfiguration("in_memory_to_throw");
            _level = new LevelModel();
        }
    }
}