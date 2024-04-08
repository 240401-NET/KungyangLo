using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace P0;

//Utils.cs contains all utilities that may be needed for this application
public class Utils  
{
    public static void waitSec(int sec)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        long numOfSec = 0;

        while(numOfSec < sec)
        {
            numOfSec = stopwatch.ElapsedTicks / Stopwatch.Frequency;
        }
    }

    public static int UserChoice(String? userSelection)
    {
        try
        {
            return Convert.ToInt32(userSelection);
        } catch(Exception)
        {
            Console.WriteLine("The selection you made did was invalid. Try again!");
            Menu.DisplayLineBreak(Console.Out, 1);
            return -1;
        }
    }

    public static int CalculateAge(DateOnly birthday)
    {      
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);

        if(birthday.DayNumber > today.DayNumber) return -1;

        int age = today.Year - birthday.Year;

        if(today.Month < birthday.Month || (today.Month == birthday.Month && today.Day < birthday.Day))
        {
            age--;
        }

        return age;
    }
    
    public static bool DateExists(string dateString, out DateOnly properDate)
    {        
        if(DateTime.TryParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime formattedDate))
        {
            properDate = DateOnly.FromDateTime(formattedDate);
            return true;
        }

        properDate = DateOnly.MinValue;
        return false;
    }

    public static bool DateCorrectFormat(string dateString)
    {
        Regex datePattern = new("^(1[0-2]|0?[1-9])/(3[01]|[12][0-9]|0?[1-9])/([0-9]{4})$");        
        return datePattern.IsMatch(dateString);
    }

    public static bool FindPet(string petName, List<Animal> petList)
    {
        return petList.Exists(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
    }

    public static void Output(TextWriter outputWriter, string output)
    {
        outputWriter.Write(output);
    }
}