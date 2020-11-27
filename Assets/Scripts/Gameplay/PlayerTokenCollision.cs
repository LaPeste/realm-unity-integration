using UnityEngine;
using System;
using System.Linq;
using Realms;

namespace Platformer.Gameplay
{
    using Core;
    using Mechanics;
    using Model;
    using Model.Statistics;

    /// <summary>
    /// Fired when a player collides with a token.
    /// </summary>
    /// <typeparam name="PlayerCollision"></typeparam>
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);

            var realm = Realm.GetInstance();
            var levelName = model.Level.Name;
            var test = realm.All<LevelStats>().ToArray();
            var level = realm.Find<LevelStats>(levelName);
            //Debug.LogWarning($"level is null= {level is null} \nfor Level name = {levelName}");
            //Debug.LogWarning($"Realm DB is stored at {RealmConfigurationBase.GetPathToRealm()}");

            realm.Write(() =>
            {
                // level is never null because added by the <see cref="ScoreController"/>
                level.CollectedTokens.Increment();
            });
            Debug.LogWarning($"Points = {level.CollectedTokens}");
        }        
    }
}