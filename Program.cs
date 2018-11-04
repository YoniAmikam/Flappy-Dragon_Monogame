using System;

namespace FlappyDragon
{
#if WINDOWS || LINUX

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (FlappyGame game = new FlappyGame())
                game.Run();
        }
    }
#endif
}
