using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{

    class AlienBouncingAction : Action
    {
        private int x = 0;
        public bool alienHitBorder;
        
        private AudioService audioService;
        private PhysicsService physicsService;
        public AlienBouncingAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }
        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> aliens = cast.GetActors(Constants.BRICK_GROUP);
            foreach (Alien alien in aliens)
            {

                Body body = alien.GetBody();
                Point position = body.GetPosition();
                int x = position.GetX();
                int y = position.GetY();
                Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
                Sound overSound = new Sound(Constants.OVER_SOUND);

                if (x < Constants.FIELD_LEFT)
                {
                    alienHitBorder = true;
                    // alien.BounceX();
                    // alien.moveDown();
                    audioService.PlaySound(bounceSound);
                }
                else if (x >= Constants.FIELD_RIGHT)
                {
                    alienHitBorder= true;
                    // alien.BounceX();
                    // alien.BounceXForEach(cast);
                    // alien.moveDown();
                    audioService.PlaySound(bounceSound);
                }
                else {
                    alienHitBorder = false;
                }

                
                if (y >= Constants.FIELD_BOTTOM)
                {
                    Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                    stats.RemoveLife();

                    if (stats.GetLives() > 0)
                    {
                        callback.OnNext(Constants.TRY_AGAIN);
                    }
                    else
                    {
                        callback.OnNext(Constants.GAME_OVER);
                        audioService.PlaySound(overSound);
                    }
                }
                
            }
            // if (x <= 10)
            // {
            //     alienHitBorder = false;

            // }
            // else {
            //     x+=1;
            //     alienHitBorder = true;
            // }
        }
        // public bool getAlienHitBorder()
        // {
        //     return alienHitBorder;
        

    }
}