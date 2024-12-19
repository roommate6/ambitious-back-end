namespace caditec_back_end.Exceptions.Startups
{
    [Serializable]
    public class StartupException : Exception
    {
        public StartupException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        { }
    }
}