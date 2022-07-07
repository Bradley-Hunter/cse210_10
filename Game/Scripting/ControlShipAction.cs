using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class ControlShipAction : Action
    {
        private KeyboardService keyboardService;

        public ControlShipAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ship racket = (Ship)cast.GetFirstActor(Constants.RACKET_GROUP);
            Laser laser = (Laser)cast.GetFirstActor(Constants.BALL_GROUP);
            if (keyboardService.IsKeyPressed(Constants.SPACE))
            {
                Body body = racket.GetBody();
                Point shipPosition = body.GetPosition();
                Point shipSize = body.GetSize();
                int x = shipPosition.GetX() + shipSize.GetX() / 2;
                laser.Release(x);
            }
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                racket.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                racket.SwingRight();
            }
            else
            {
                racket.StopMoving();
            }
        }
    }
}