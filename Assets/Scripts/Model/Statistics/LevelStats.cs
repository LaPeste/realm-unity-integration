using System;
using UnityEngine;
using Realms;

namespace Platformer.Model.Statistics
{
    public class LevelStats : RealmObject
    {
        [PrimaryKey]
        public string Name { get; set; }

        /// Sum of tokes + killed enemies
        public int Points { get; set; }
        public DateTimeOffset BestTimeToEnd { get; set; }
        
        // TODO check if to make these 2 below RealmInteger<int> since they are counters
        public RealmInteger<int> CollectedTokens { get; set; }
        public RealmInteger<int> DeathsCounter { get; set; }

        public LevelStats()
        {
            BestTimeToEnd = new DateTimeOffset();
            CollectedTokens = DeathsCounter = Points = 0;
        }
    }
    
}