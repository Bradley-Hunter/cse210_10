using System;
using cse210_10.Game.Casting;
using cse210_10.Game.Services;


namespace cse210_10.Game.Scripting
{
    public class TimedChangeSceneAction : Action
    {
        private string nextScene;
        private double delay;
        private DateTime start;
        
        public TimedChangeSceneAction(string nextScene, double delay, DateTime start)
        {
            this.nextScene = nextScene;
            this.delay = delay;
            this.start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            if (elapsedTime.Seconds > delay)
            {
                callback.OnNext(nextScene);
            }
        }
    }
}