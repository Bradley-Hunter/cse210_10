using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class ControlRacketAction : Action
    {
        private KeyboardService keyboardService;

        public ControlRacketAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
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