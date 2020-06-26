
### xResult (Prototype) 🚦

## What is xResult?

It represents APIs that help to write functional codes in c#!

```c#
using static xResult.Result;

public class User
{
    private User(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; }

    public static Result<User> New(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return Fail("The UserName is required!");
        }
        return Ok(new User(userName));
    }
}
```


