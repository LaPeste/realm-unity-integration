using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Model
{
    public class LevelModel
    {
        private string _levelName;
        public string Name => _levelName;

        public LevelModel()
        {
            // TODO find a better way to name this
            _levelName = "BlueCity";//SceneManager.GetActiveScene().name;
        }
    }
}