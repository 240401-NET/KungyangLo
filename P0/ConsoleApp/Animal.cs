namespace P0;

public class Animal(string name, string animalType = "TBD", DateOnly? birthday = null, string description = "TBD")
{
    private string name = name;
    private string animalType = animalType;
    private DateOnly birthday = birthday ?? DateOnly.MinValue;
    private string description = description;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string AnimalType
    {
        get => animalType;
        set => animalType = value;
    }

    public DateOnly BirthDay
    {
        get => birthday;
        set => birthday = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }

    public int PetAge()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        return 0;
    }

    public override string ToString()
    {
        string animalInfo = $"Name: {name}\nType: {animalType}\nBirthday: {birthday}\nDescription: {description}";
        return animalInfo;
    }
}