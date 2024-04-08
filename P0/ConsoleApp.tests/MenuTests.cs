using System.Text;
using P0;

namespace ConsoleApp.tests;

public class MenuTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Menu_DisplayLineBreak_NumberofBreaks(int numOfBreaks)
    {
        StringBuilder sb = new();
        StringWriter sw = new(sb);

        Menu.DisplayLineBreak(sw, numOfBreaks);
        int count = sb.ToString().Count(c => c == '\n');

        Console.WriteLine(count);
        Console.WriteLine(numOfBreaks);
        
        Assert.Equal(numOfBreaks, count);
    }
}