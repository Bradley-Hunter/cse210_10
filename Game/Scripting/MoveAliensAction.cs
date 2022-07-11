using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{

    public class MoveAliensAction : Action
    {
        
        public static AudioService AudioService = new RaylibAudioService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        AlienBouncingAction alienbouncing = new AlienBouncingAction(PhysicsService, AudioService);
        
        private int countdown = 0;
        
        private int xSteps = 9;
        

        
        public MoveAliensAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> aliens = cast.GetActors(Constants.BRICK_GROUP);
            if (countdown <= 0) 
            {
                countdown = 30;
                xSteps -= 1;

                foreach (Actor actor in aliens) 
                {
                    Alien alien = (Alien)actor;
                    Body body = alien.GetBody();
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    position = position.Add(velocity);
                    body.SetPosition(position);
                    
                    // if (alienbouncing.alienHitBorder == true) {
                    //     alien.BounceX();
                    //     alien.moveDown();
                    // }
                    if (xSteps <= 0)
                    {
                        alien.BounceX();
                        alien.moveDown();
                    }
                }
                if (xSteps <= 0) {
                    xSteps = 8;
                }
            }
            else {
                countdown -= 1;
            }
        

        }
    }
}
