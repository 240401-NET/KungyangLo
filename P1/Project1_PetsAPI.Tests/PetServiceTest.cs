using Moq;
using Project1_PetsAPI.Models;
using Project1_PetsAPI.Services;
using Project1_PetsAPI.Data;

namespace Project1_PetsAPI.Tests;

public class PetServiceTest
{
    [Fact]
    public void PetServiceGetAllPets()
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        IEnumerable<Pet> fakePets = [
            new Pet{Id = 1, Name = "Nyla"}
        ];       
    
        DAOMock.Setup(repo => repo.GetAllPets()).Returns(fakePets);
        PetService service = new PetService(DAOMock.Object);

        //Act
        IEnumerable<Pet> allPets = service.GetAllPets();
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.Single(allPets);
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.GetAllPets(), Times.Exactly(1));        
    }

    [Theory]
    [InlineData("Cookie")]
    [InlineData("Nyla")]
    [InlineData("Mimi")]
    public void PetServiceCreateNewPet(string name)
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        Pet myPet = new Pet();
        myPet.Name = name;

        IEnumerable<Pet> fakePets = [
            new Pet{Id = 1, Name = "Steve"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 3, Name = name}
        ];        
    
        DAOMock.Setup(repo => repo.CreateNewPet(myPet)).Returns(fakePets.FirstOrDefault(p => p.Name == name)!);
        PetService service = new PetService(DAOMock.Object);

        //Act
        Pet newPet = service.CreateNewPet(myPet);
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.NotNull(newPet);
        Assert.Equal(name, newPet.Name);
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.CreateNewPet(myPet), Times.Exactly(1));        
    }

    [Theory]
    [InlineData(1, "Steve")]
    [InlineData(2, "Bob")]
    [InlineData(3, "Doodle")]
    public void PetServiceGetPetByIdReturnsCorrectPet(int id, string name)
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        IEnumerable<Pet> fakePets = [
            new Pet{Id = 1, Name = "Steve"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 3, Name = "Doodle"}
        ];        
    
        DAOMock.Setup(repo => repo.GetPetById(id)).Returns(fakePets.FirstOrDefault(p => p.Id == id)!);
        PetService service = new PetService(DAOMock.Object);

        //Act
        Pet? foundPet = service.GetPetById(id);
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.NotNull(foundPet);
        Assert.Equal(name, foundPet.Name);
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.GetPetById(id), Times.Exactly(1));        
    }

    [Fact]
    public void PetServiceGetPetByIdReturnsNullWhenPetNotFound()
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        IEnumerable<Pet> fakePets = [
            new Pet{Id = 1, Name = "Steve"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 3, Name = "Doodle"}
        ];        
    
        DAOMock.Setup(repo => repo.GetPetById(100)).Returns(fakePets.FirstOrDefault(p => p.Id == 100)!);
        PetService service = new PetService(DAOMock.Object);

        //Act
        Pet? foundPet = service.GetPetById(100);
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.Null(foundPet);
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.GetPetById(100), Times.Exactly(1));        
    }

    [Theory]
    [InlineData("Steve", 1)]
    [InlineData("Bob", 4)]
    [InlineData("Doodle", 3)]
    public void PetServiceGetPetByNameReturnsCorrectNumber(string name, int numOfCopy)
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        IEnumerable<Pet> fakePets = [
            new Pet{Id = 1, Name = "Steve"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 3, Name = "Doodle"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 2, Name = "Doodle"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 2, Name = "Doodle"},
        ];        
    
        DAOMock.Setup(repo => repo.GetPetsByName(name)).Returns(fakePets.Where(p => p.Name == name)!);
        PetService service = new PetService(DAOMock.Object);

        //Act
        IEnumerable<Pet> petSearchList = service.GetPetsByName(name);
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.NotNull(petSearchList);
        Assert.Equal(numOfCopy, petSearchList.Count());
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.GetPetsByName(name), Times.Exactly(1));        
    }

    [Fact]
    public void PetServiceUpdatePetByIdCorrectly()
    {
        // Arrange
        Mock<IPetDAO> DAOMock = new();

        List<Pet> fakePets = [
            new Pet{Id = 1, Name = "Steve"},
            new Pet{Id = 2, Name = "Bob"},
            new Pet{Id = 3, Name = "Doodle"}
        ];

        int id = 1;
        Pet newPet = new();
        newPet.Name = "Goofball";       
    
        DAOMock.Setup(repo => repo.GetPetById(id)).Returns(fakePets.FirstOrDefault(p => p.Id == id)!);
        DAOMock.Setup(repo => repo.UpdatePetById(id, newPet))
            .Callback(() => fakePets.First(p => p.Id == id).Name = newPet.Name)
            .Returns(fakePets.First(p => p.Id == id));

        PetService service = new PetService(DAOMock.Object);

        //Act
        Pet updatedPet = service.UpdatePetById(id, newPet);
        
        //Assert
        // Check to verify we actually got the data we faked
        //Assert.NotNull(updatedPet);
        Assert.Equal(newPet.Name, updatedPet.Name);
        // Also check that GetAllPets of PetRepository was called Only Once
        DAOMock.Verify(repo => repo.GetPetById(id), Times.Exactly(1));
        DAOMock.Verify(repo => repo.UpdatePetById(id, newPet), Times.Exactly(1));        
    }

}