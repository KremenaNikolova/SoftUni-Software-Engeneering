namespace Library.Commons.Valdiations
{
    public static class BookValidations
    {
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;

        public const int AuthorMinLength = 5;
        public const int AuthorMaxLength = 50;

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 5000;

        public const double RatingMinValue = 0;
        public const double RatingMaxValue = 10;
    }
}
