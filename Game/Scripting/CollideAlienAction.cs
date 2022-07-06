using System.Collections.Generic;
using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class CollideAlienAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideAlienAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Laser ball = (Laser)cast.GetFirstActor(Constants.BALL_GROUP);
            List<Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            
            foreach (Actor actor in bricks)
            {
                Alien brick = (Alien)actor;
                Body brickBody = brick.GetBody();
                Body ballBody = ball.GetBody();

                if (physicsService.HasCollided(brickBody, ballBody))
                {
                    ball.BounceY();
                    Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    audioService.PlaySound(sound);
                    int points = brick.GetPoints();
                    stats.AddPoints(points);
                    cast.RemoveActor(Constants.BRICK_GROUP, brick);
                }
            }
        }
    }
}