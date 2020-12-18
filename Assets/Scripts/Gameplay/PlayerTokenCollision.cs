using UnityEngine;
using Realms;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using Platformer.Utils;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        private readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);

            using (var realm = Realm.GetInstance())//(model.realmConf))
            {
                var stats = RealmUtils.GetOrCreateStats(realm, model.Level.Name);
                realm.Write(() =>
                {
                    stats.CollectedTokens.Increment();
                });
            }
        }
    }
}