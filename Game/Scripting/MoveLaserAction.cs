using cse210_10.Game.Casting;
namespace cse210_10.Game.Scripting
{
    public class MoveLaserAction : Action
    {
        public MoveLaserAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Laser ball = (Laser)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
        }
    }
}