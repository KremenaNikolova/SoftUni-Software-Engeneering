using System;

namespace P01.Stream_Progress
{
    public class StartUp
    {
        static void Main()
        {
            IStreamable stremas = new IStreamable();
            IStreamable file = new File("Example", 2000, 200);
            IStreamable music = new Music("2pac", "All eyes on me", 3000, 420);

            StreamProgressInfo streamProgressInfoTest1 = new StreamProgressInfo(file);

            StreamProgressInfo streamProgressInfoTest2 = new StreamProgressInfo(music);
        }
    }
}
