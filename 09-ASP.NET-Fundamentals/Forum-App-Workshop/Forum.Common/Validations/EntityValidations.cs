namespace Forum.Common.Validations
{
    public static class EntityValidations
    {
        public static class PostValidation
        {
            public const int MinTitleLength = 10;
            public const int MaxTitleLength = 50;

            public const int MinContentLength = 30;
            public const int MaxContentLength = 1500;
        }
    }
}
