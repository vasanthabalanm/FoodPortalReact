namespace FoodOrderApplication.ExceptionsHandler
{
    public class NotFoundExceptionHandler(string message) : Exception
    {
        string message = message;

        public override string Message
        {
            get { return message; }
        }
    }
}
