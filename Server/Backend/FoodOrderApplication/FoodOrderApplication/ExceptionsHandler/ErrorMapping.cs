namespace FoodOrderApplication.ExceptionsHandler
{
    public class ErrorMapping
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ErrorMapping(int ID, string Message)
        {
            this.StatusCode = ID;
            this.Message = Message;
        }
    }
}
