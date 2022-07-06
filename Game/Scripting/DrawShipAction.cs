using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class DrawShipAction : Action
    {
        private VideoService videoService;
        
        public DrawShipAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ship racket = (Ship)cast.GetFirstActor(Constants.RACKET_GROUP);
            Body body = racket.GetBody();

            if (racket.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Animation animation = racket.GetAnimation();
            Image image = animation.NextImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}