using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using Realms;
using System.IO;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Awake()
        {
            var realmPath = Path.Combine(Utils.MultiOsUtils.GetWritableOsLocation(), "realm_test_db");

            RealmConfiguration.DefaultConfiguration = new RealmConfiguration(realmPath)
            {
                ShouldDeleteIfMigrationNeeded = true
            };
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }

        void OnApplicationQuit()
        {
            Debug.LogWarning("Application ending after " + Time.time + " seconds");
        }
    }
}