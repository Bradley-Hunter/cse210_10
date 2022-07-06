using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class LoadAssetsAction : Action
    {
        private AudioService audioService;
        private VideoService videoService;
        
        public LoadAssetsAction(AudioService audioService, VideoService videoService)
        {
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            audioService.LoadSounds("Assets/Sounds");
            videoService.LoadFonts("Assets/Fonts");
            videoService.LoadImages("Assets/Images");
        }
    }
}