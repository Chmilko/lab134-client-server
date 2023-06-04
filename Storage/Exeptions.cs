namespace lab123.Storage
{
    [System.Serializable]
    public class IncorrectDataException : System.Exception
    {
        public IncorrectDataException() { }
        public IncorrectDataException(string message) : base(message) { }
        public IncorrectDataException(string message, System.Exception inner) : base(message, inner) { }
        protected IncorrectDataException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
