using System.Collections.Generic;
using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class DrawAliensAction : Action
    {
        private VideoService videoService;
        
        public DrawAliensAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);
            foreach (Actor actor in bricks)
            {
                Alien brick = (Alien)actor;
                Body body = brick.GetBody();

                if (brick.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = brick.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}