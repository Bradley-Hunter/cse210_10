using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class DrawLaserAction : Action
    {
        private VideoService videoService;
        
        public DrawLaserAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Laser ball = (Laser)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();

            if (ball.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Image image = ball.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}