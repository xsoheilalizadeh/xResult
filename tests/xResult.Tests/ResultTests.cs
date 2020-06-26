using System;
using Xunit;

namespace xResult.Tests
{
    public class ResultTests
    {
        [Fact]
        public void VoidOk()
        {
            var result = Order.VoidOk();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void VoidFail()
        {
            var error = "The error";

            var result = Order.VoidFail(error);

            Assert.False(result.Succeeded);
            Assert.Equal(result.Error, error);
        }

        [Fact]
        public void OkWithValue()
        {
            var value = "The Value";

            var result = Order.OkWithValue(value);

            Assert.Equal(value, result.Value);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void FailWithError()
        {
            var error = "The Error";

            var result = Order.FailWithStringError(error);

            Assert.True(error == result.Error);
            Assert.True(result.Error == error);
            Assert.True(error.Equals(error));
            Assert.True(result.Error.Equals(error));
            Assert.False(result.Succeeded);
        }

        [Fact]
        public void FailWithCustomError()
        {
            var error = new CustomError("The custom error");

            var result = Order.FailWithCustomError(error);

            Assert.True(error == result.Error);
            Assert.True(result.Error == error);
            Assert.True(error.Equals(error));
            Assert.True(result.Error.Equals(error));
            Assert.Equal(result.Error.CustomValue, error.CustomValue);
            Assert.False(result.Succeeded);
        }
    }
}