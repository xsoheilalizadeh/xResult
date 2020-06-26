
### xResult 🚦

What is xResult?

It's represents APIs that helps to write functional codes in c#!

```c#
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


