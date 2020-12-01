using Realms;

namespace Platformer.Model.Statistics
{
    public class LevelStats : RealmObject
    {
        [PrimaryKey]
        public string Name { get; private set; }

        public RealmInteger<int> CollectedTokens { get; private set; }
        public RealmInteger<int> DeathsCounter { get; private set; }

        private LevelStats()
        {
        }

        public LevelStats(string levelName)
        {
            Name = levelName;
        }
    }
}