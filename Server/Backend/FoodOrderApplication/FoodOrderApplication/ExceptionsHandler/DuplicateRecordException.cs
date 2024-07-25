namespace FoodOrderApplication.ExceptionsHandler
{
    public class DuplicateRecordException : Exception
    {
        string message;
        public DuplicateRecordException()
        {
            message = "This mail is already exsist";
        }
        public DuplicateRecordException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}