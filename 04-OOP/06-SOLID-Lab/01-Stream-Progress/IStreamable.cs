namespace P01.Stream_Progress
{
    public interface IStreamable //f a new kind of stream is introduced, you will need to just import one new class with  BytesSent and Length getters in it. 
    {
        int BytesSent { get; set; }
        int Length { get; set; }
    }
}