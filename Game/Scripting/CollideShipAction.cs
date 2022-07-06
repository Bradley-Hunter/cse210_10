using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class CollideShipAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        
        public CollideShipAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Laser ball = (Laser)cast.GetFirstActor(Constants.BALL_GROUP);
            Ship racket = (Ship)cast.GetFirstActor(Constants.RACKET_GROUP);
            Body ballBody = ball.GetBody();
            Body racketBody = racket.GetBody();

            if (physicsService.HasCollided(racketBody, ballBody))
            {
                ball.BounceY();
                Sound sound = new Sound(Constants.BOUNCE_SOUND);
                audioService.PlaySound(sound);
            }
        }
    }
}