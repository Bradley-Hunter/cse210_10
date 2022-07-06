using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class UnloadAssetsAction : Action
    {
        private AudioService audioService;
        private VideoService videoService;
        
        public UnloadAssetsAction(AudioService audioService, VideoService videoService)
        {
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            audioService.UnloadSounds();
            videoService.UnloadFonts();
            videoService.UnloadImages();
        }
    }
}