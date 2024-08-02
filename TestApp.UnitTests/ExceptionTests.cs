using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "word";
        string expected = "drow";

        // Act
        string actual = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100m;
        decimal discount = 20m;
        decimal expected = 80m;

        // Act
        decimal actual = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 120;
        decimal discount = -15;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] input = { 2, 4, 16, 2, 5 };
        int index = 2;
        int expected = 16;

        // Act
        int actual = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 4, 88, 3, 2, 2, 5 , 1 };
        int index = -10;

        // Act & Assert
        //Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 22, 1, -6, 55, 4, 2, 33 };
        int index = 7;

        // Act & Arranges
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.IndexOutOfRangeGetElement(input, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLoggedIn = true;
        string expected = "User logged in.";

        // Act
        string actual = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool isLoggedIn = false;

        // Act & Assert
        InvalidOperationException result = Assert.Throws<InvalidOperationException>(() => _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn));

        Assert.That(result.Message, Is.EqualTo("User must be logged in to perform this operation."));
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "53";
        int expected = 53;

        // Act
        int actual = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "five";

        // Act && Assert
        Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(input));

    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            ["firstKey"] = 1,
            ["secondKey"] = 2,
            ["thirdKey"] = 3
        };

        string key = "secondKey";
        int expected = 2;

        // Act
        int actual = _exceptions.KeyNotFoundFindValueByKey(dictionary, key);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            ["firstKey"] = 1,
            ["secondKey"] = 2,
            ["thirdKey"] = 3
        };
        string invalidKey = "number";

        // Act && Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.KeyNotFoundFindValueByKey(dictionary, invalidKey));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 50;
        int b = 226;
        int expected = 276;

        // Act
        int actual = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act && Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));

    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act && Assert
        Assert.Throws<OverflowException>(() => _exceptions.OverflowAddNumbers(a, b));

    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 10;
        int divisor = 5;
        double expected = 2;

        // Act
        double actual = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 20;
        int divisor = 0;

        // Act && Assert
        Assert.Throws<DivideByZeroException>(() => _exceptions.DivideByZeroDivideNumbers(dividend, divisor));
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] collection = new int[] { 1, 5, 15, 9, 3 };
        int index = 2;
        int expected = 33;

        // Act
        int actual = _exceptions.SumCollectionElements(collection, index);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange && Act && Assert
        Assert.Throws<ArgumentNullException>(() => _exceptions.SumCollectionElements(null, 2));
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] collection = new int[] { 22, 33, 2, 5, 1, 2 };
        int index = 6;

        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => _exceptions.SumCollectionElements(collection, index));
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            ["firsKey"] = "1",
            ["secondKey"] = "2",
            ["thirdKey"] = "3"
        };
        string key = "secondKey";
        int expected = 2;

        // Act
        int actual = _exceptions.GetElementAsNumber(dictionary, key);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            ["firstKey"] = "1",
            ["secondKey"] = "2",
            ["thirdKey"] = "3"
        };
        string invalidKey = "fifthKey";

        // Act && Assert
        Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(dictionary, invalidKey));

    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            ["firstKey"] = "1",
            ["secondKey"] = "2",
            ["thirdKey"] = "3",
            ["forthKey"] = "four"
        };
        string key = "forthKey";

        // Act && Assert
        Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(dictionary, key));

    }
}
