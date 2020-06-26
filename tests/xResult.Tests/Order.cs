using static xResult.Result;
    
namespace xResult.Tests
{
    public class Order
    {
        public int Id { get; }

        public Order(int id)
        {
            Id = id;
        }

        public static Result VoidOk()
        {
            return Ok();
        }
        
        public static Result VoidFail(string error)
        {
            return Fail(error);
        }
   
        public static Result<string> OkWithValue(string value)
        {
            return Ok(value);
        }

        
        public static Result<int> FailWithStringError(string error)
        {
            return Fail(error);
        }

        public static Result<int, CustomError> FailWithCustomError(CustomError error)
        {
            return Fail(error);
        }
    }
}