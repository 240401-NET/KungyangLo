namespace P0;

//Animal class that creates object that represents pets that may be added to the app
public class Animal
{
    private string name = "";
    private string animalType = "";
    private DateOnly birthday = DateOnly.MinValue;

    public Animal(){}

    public Animal(string name, string animalType = "TBD", DateOnly? birthday = null)
    {
        this.name = name;
        this.animalType = animalType;
        this.birthday = birthday ?? DateOnly.MinValue;
    }
    
    public string Name
    {
        get => name;
        set => name = value;
    }

    public string AnimalType
    {
        get => animalType;
        set
        {
            if(!String.IsNullOrEmpty(value?.Trim()))
            {
                animalType = value.Trim();
            }
        }
    }

    public DateOnly BirthDay
    {
        get => birthday;
        set => birthday = value;
    }

    public int PetAge()
    {
        return Utils.CalculateAge(this.birthday);
    }

    public override string ToString()
    {
        bool hasBirthDay = birthday.Equals(DateOnly.MinValue);        
        string birthdayString = hasBirthDay ? "Birthday: No bDay (-_-)'" : $"Birthday: {birthday.ToString()}";
        string petAge = hasBirthDay ? "" : $"\nAge: {PetAge()}";        
        string animalInfo = $"Name: {name}\nType: {animalType}\n{birthdayString}{petAge}";
        return animalInfo;
    }
}