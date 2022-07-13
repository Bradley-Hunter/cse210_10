using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{

    public class MoveAliensAction : Action
    {

        public static AudioService AudioService = new RaylibAudioService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();
        AlienBouncingAction alienbouncing = new AlienBouncingAction(PhysicsService, AudioService);
        private int reverse;

        private int countdown = 0;


        public MoveAliensAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> aliens = cast.GetActors(Constants.BRICK_GROUP);
            reverse = 0;
            foreach (Actor actor in aliens)
            {
                Alien alien = (Alien)actor;
                Body body = alien.GetBody();
                Point position = body.GetPosition();
                int x = position.GetX();
                int y = position.GetY();
                if ((x >= Constants.FIELD_RIGHT - (Constants.BRICK_WIDTH * 2) || x < Constants.FIELD_LEFT) && reverse == 0)
                {
                    cast.ReverseActorsXVelocity(Constants.BRICK_GROUP);
                    reverse = 1;
                }

            }

            if (countdown <= 0)
            {
                countdown = 100;
                foreach (Actor actor in aliens)
                {
                    Alien alien = (Alien)actor;
                    Body body = alien.GetBody();
                    Point position = body.GetPosition();
                    Point velocity = body.GetVelocity();
                    position = position.Add(velocity);
                    body.SetPosition(position);

                }
            }
            else
            {
                countdown -= 1;
            }

        }
    }
}
