using System;
using cse210_10.Game.Directing;
using cse210_10.Game.Services;

namespace cse210_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
