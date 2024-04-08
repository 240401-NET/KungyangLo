using P0;

namespace ConsoleApp.tests;

public class UtilsTests
{
    [Fact]
    public void Utils_UserChoice_ReturnInt()
    {
        string input = "0";
        var result = Utils.UserChoice(input);
        Assert.IsType<int>(result);
    }
    
    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("6", 6)]
    [InlineData("7", 7)]
    [InlineData("8", 8)]
    [InlineData("9", 9)]
    public void Utils_UserChoice_ReturnCorrectNumber(string input, int expected)
    {
        int result = Utils.UserChoice(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Utils_CalculateAge_ReturnInt()
    {
        DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
        var result = Utils.CalculateAge(todayDate);
        Assert.IsType<int>(result);
    }

    public static IEnumerable<object[]> Birthdays
    {
        get
        {
            yield return new object[] { new DateOnly(1990, 01, 01),  (new DateTime(1, 1, 1) + (DateTime.Now - new DateTime(1990, 01, 01))).Year - 1};
            yield return new object[] { new DateOnly(1997, 01, 01),  (new DateTime(1, 1, 1) + (DateTime.Now - new DateTime(1997, 01, 01))).Year - 1};
            yield return new object[] { new DateOnly(2004, 01, 01),  (new DateTime(1, 1, 1) + (DateTime.Now - new DateTime(2004, 01, 01))).Year - 1};
            yield return new object[] { new DateOnly(2011, 01, 01),  (new DateTime(1, 1, 1) + (DateTime.Now - new DateTime(2011, 01, 01))).Year - 1};
            yield return new object[] { new DateOnly(1992, 10, 14),  (new DateTime(1, 1, 1) + (DateTime.Now - new DateTime(1992, 10, 14))).Year - 1};
        }
    }

    [Theory]
    [MemberData(nameof(Birthdays))]
    public void Utils_CalculateAge_ReturnCorrectAge(DateOnly birthday, int expected)
    {
        int result = Utils.CalculateAge(birthday);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Utils_DateExists_ReturnBool()
    {
        string dateInput = "1/1/1990";
        var result = Utils.DateExists(dateInput, out _);
        Assert.IsType<bool>(result);
    }

    [Theory]
    [InlineData("4/9/2024", true)]
    [InlineData("6/6/2020", true)]
    [InlineData("9/11/1980", true)]
    [InlineData("2/31/2001", false)]
    [InlineData("4/31/1980", false)]
    [InlineData("2/29/2003", false)]
    public void Utils_DateExists_CheckDates(string dateInput, bool expected)
    {
        bool result = Utils.DateExists(dateInput, out _);
        Assert.Equal(expected, result);
    }
}
