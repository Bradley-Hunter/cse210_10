using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            if (keyboardService.IsKeyPressed(Constants.ENTER))
            {
                callback.OnNext(nextScene);
            }
        }
    }
}