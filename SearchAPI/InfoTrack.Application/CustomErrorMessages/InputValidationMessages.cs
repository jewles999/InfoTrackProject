namespace InfoTrack.Application.CustomErrorMessages
{
    public static class InputValidationMessages
    {
        public const string SearchTermErrorMessage = "Input must contain letters or digits only. Spaces are allowed";
        public const string DomainFormatErrorMessage = "Domain name is invalid. Can contain letters, digits, and a suffix, e.g. .com";
    }
}
