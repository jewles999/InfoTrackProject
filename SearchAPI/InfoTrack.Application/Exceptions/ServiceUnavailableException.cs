namespace InfoTrack.Application.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException()
            : base(CustomErrorMessages.ExceptionMessages.SystemUnavailableMessage)
        {
        }
    }
}
