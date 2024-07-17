namespace HotelManageOrders.ExceptionHandlers
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