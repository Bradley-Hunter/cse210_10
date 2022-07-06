using System.Collections.Generic;
using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class DrawDialogAction : Action
    {
        private VideoService videoService;
        
        public DrawDialogAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> actors = cast.GetActors(Constants.DIALOG_GROUP);
            foreach (Actor actor in actors)
            {
                Label label = (Label)actor;
                Text text = label.GetText();
                Point position = label.GetPosition();
                videoService.DrawText(text, position);
            }
        }
    }
}