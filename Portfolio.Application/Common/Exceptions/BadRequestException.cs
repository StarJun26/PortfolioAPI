namespace Portfolio.Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public string[] Errors { get; set; }

        public BadRequestException() : base() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string[] errors) : base("Multiple errors occured. See error details for more information.") 
        {
            Errors = errors;
        }
    }
}
