using System.ComponentModel;
using Platformer.Core;
using Platformer.Model;
using Platformer.Model.Statistics;
using Platformer.Utils;
using Realms;
using UnityEngine;  
using UnityEngine.UI;

namespace Platformer.UI.InGame
{

    public class ScoreController : MonoBehaviour
    {
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        private Realm _realm;
        private Text _textLabel;
        // just a ref to prevent it from being GCed and not receiveing notification changes
        private LevelStats _levelStats;

        private void Start()
        {
            _realm = Realm.GetInstance();
            _textLabel = GetComponent<Text>();
            _levelStats = RealmUtils.GetOrCreateStats(_realm, model.Level.Name);

            _textLabel.text = _levelStats.CollectedTokens.ToString();
            _levelStats.PropertyChanged += OnLevelStatsPropertyChanged;
        }

        private void OnDestroy()
        {
            _levelStats.PropertyChanged -= OnLevelStatsPropertyChanged;
            _levelStats = null;
            _realm.Dispose();
        }

        private void OnLevelStatsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LevelStats.CollectedTokens))
            {
                _textLabel.text = _levelStats.CollectedTokens.ToString();
            }
        }
    }
}