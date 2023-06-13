namespace Library.Commons.ErrorMessages
{
    public static class BookErrorMessages
    {
        public const string TitleErrorMessage = "Title can not be less than 10 symbols and no more of 50 symbols";

        public const string AuthorErrorMessage = "Author can not be less than 5 symbols and no more of 50 symbols";

        public const string DescriptionErrorMessage = "Description can not be less than 5 symbols and no more of 5000 symbols";

        public const string ImageUrlErrorMessage = "You cannot add book without Image";

        public const string RatingErrorMessage = "Rating must be between 0.00 and 10.00";
    }
}
