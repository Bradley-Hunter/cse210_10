using cse210_10.Game.Casting;

namespace cse210_10.Game.Scripting
{
    public class MoveShipAction : Action
    {
        public MoveShipAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ship racket = (Ship)cast.GetFirstActor(Constants.RACKET_GROUP);
            Body body = racket.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            int x = position.GetX();

            position = position.Add(velocity);
            if (x < 0)
            {
                position = new Point(0, position.GetY());
            }
            else if (x > Constants.SCREEN_WIDTH - Constants.RACKET_WIDTH)
            {
                position = new Point(Constants.SCREEN_WIDTH - Constants.RACKET_WIDTH, 
                    position.GetY());
            }

            body.SetPosition(position);       
        }
    }
}