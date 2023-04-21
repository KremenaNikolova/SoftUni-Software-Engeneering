using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo //can work with different kind of streams
    {
        private IStreamable file;

        public StreamProgressInfo(IStreamable file)
        {
            this.file = file;
        }

        // If we want to stream a music file, we can't ---> first we must fix that


        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
