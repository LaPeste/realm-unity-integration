using System.IO;
using Platformer.Model.Statistics;
using Realms;

namespace Platformer.Utils
{
    public static class RealmUtils
    {
        public static void Init()
        {
            var realmPath = Path.Combine(MultiOsUtils.GetWritableOsLocation(), "realm_test_db");

            RealmConfiguration.DefaultConfiguration = new RealmConfiguration(realmPath)
            {
                ShouldDeleteIfMigrationNeeded = true
            };
        }

        public static LevelStats GetOrCreateStats(Realm realm, string levelName)
        {
            var levelStats = realm.Find<LevelStats>(levelName);
            if (levelStats is null)
            {
                realm.Write(() =>
                {
                    // Look up the stats object while holding a transaction lock - it's possible that
                    // someone created it on a different thread.
                    levelStats = realm.Find<LevelStats>(levelName);
                    if (levelStats is null)
                    {
                        levelStats = realm.Add(new LevelStats(levelName));
                    }
                });
            }

            return levelStats;
        }
    }
}
