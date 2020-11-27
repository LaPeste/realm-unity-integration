using UnityEngine;  
using UnityEngine.UI;
using System;
using Realms;

namespace Platformer.UI.InGame
{
    using Model;
    using Model.Statistics;
    using Core;

    public class ScoreController : MonoBehaviour
    {
        private Text textLabel;
        private PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        // just a ref to prevent it from being GCed and not receiveing notification changes
        private LevelStats _levelStats;

        private void Start()
        {
            textLabel = GetComponent<Text>();
            var realm = Realm.GetInstance();
            var levelName = model.Level.Name;
            _levelStats = realm.Find<LevelStats>(levelName);
            if (_levelStats is null)
            {
                realm.Write(() =>
                {
                    if (_levelStats is null)
                    {
                        _levelStats = new LevelStats
                        {
                            Name = levelName,
                        };
                        realm.Add(_levelStats);
                    }
                });
            }
            textLabel.text = _levelStats.CollectedTokens.ToString();
            _levelStats.PropertyChanged += OnRealmChanged;
        }

        private void OnDestroy()
        {
            var realm = Realm.GetInstance();
            realm.RealmChanged -= OnRealmChanged;
        }

        private void Update()
        {
                   
        }

        private void OnRealmChanged(object sender, EventArgs eventArgs)
        {
            var realm = Realm.GetInstance();
            var levelName = model.Level.Name;
            textLabel.text = _levelStats.CollectedTokens.ToString();
        }
    }
}