namespace xResult.Tests
{
    public class CustomError : IError
    {
        public CustomError(string customValue)
        {
            CustomValue = customValue;
        }

        public void Throw()
        {
        }

        public string CustomValue { get; set; }
    }
}