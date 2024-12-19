// create abstract factory to create animals

using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;
using System.Drawing;
using System.Text;


#region Домашка
Console.OutputEncoding = Encoding.UTF8; // Інакше українське "і" не виводилось.
Console.Title = "Домашка №5";

static void PrintCollection(System.Collections.IEnumerable collection, string msg = "")
{
    if (msg.Length > 0)
        Console.WriteLine(msg);
    foreach (var obj in collection)
    {
        Console.WriteLine($"  {obj?.ToString()}");
    }
    Console.WriteLine();
}

#endregion


var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
var animalAges = new int[] { 1, 2, 3, 4, 5, 10 };
var colors = new Color[] { Color.Black, Color.White, Color.Silver, Color.Blue };

var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" };
var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };
var ownerAges = new int[] { 10, 20, 23, 14, 35, 90 };

var list = new List<int>();

IAnimalFactory animalFactory = new AnimalFactory();
var random = new Random();
var cats = new GenericHotel<Cat>();
var genericHotel = new GenericHotel<IAnimal>();
var kyivHotel = new KyivHotel();
var romashkaHotel = new RomashkaHotel();

for (var i = 0; i < 10; i++)
{
    var animalName = animalNames[random.Next(animalNames.Length)];

    var animalAge = animalAges[random.Next(animalAges.Length)];
    var animalColor = colors[random.Next(colors.Length)];
    var ownerName = ownerNames[random.Next(ownerNames.Length)];
    var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
    var ownerAge = ownerAges[random.Next(ownerAges.Length)];
    var animalType = random.Next(2);

    var owner = new Owner(ownerName, ownerPhoneNumber, ownerAge);
    IAnimal animal = animalType switch
    {
        0 => animalFactory.CreateDog(animalName, owner, animalAge, animalColor),
        1 => animalFactory.CreateCat(animalName, owner, animalAge, animalColor),
        _ => throw new ArgumentException("Invalid animal type"),
    };

    /*IAnimal oldSchool = default;
    
    switch (animalType)
    {
        case 0:
            break;
        case 1:
            oldSchool = animalFactory.CreateCat(animalName, owner);
            break;
        default:
            throw new ArgumentException("Invalid animal type");
            break;
    }*/
    genericHotel.AddAnimal(animal);
    //genericHotel.AddAnimal(oldSchool);
    kyivHotel.AddAnimal(animal);
    //kyivHotel.AddAnimal(oldSchool);
    romashkaHotel.AddAnimal(animal);
    //romashkaHotel.AddAnimal(oldSchool);
}




//Код который пришел в ДЗ.
// Теоретически в коллекции мог влетать нулл. Поправил на уровне метода AddAnimal каждого из отелей
//genericHotel.AddAnimal(null);

foreach (var animal in genericHotel)
{
    Console.WriteLine(animal.Name);
    animal.Eat();
}

foreach (var animal in kyivHotel)
{
    Console.WriteLine(animal.Name);
    animal.Sleep();
}

//romashkaHotel.AddAnimal("XX");

foreach (var animal in romashkaHotel)
{
    // Здесь теоретически мог быть  нулл в animal as IAnimal. Потому что ромашка могла содержать и не животных. Поправил и тут и в методе AddAnimal
    Console.WriteLine((animal as IAnimal)?.Name);
}




// TODO: get all animals with name 'Parrot' from genericHotel
var genericHotelParrots = genericHotel.Where(x => x.Name == "Parrot");
PrintCollection(genericHotelParrots, $"Тварини з іменем  \"Parrot\" у genericHotel");

// TODO: get all animals with name 'Parrot' from kyivHotel
var kyivHotelParrots = kyivHotel.Where(x => x.Name == "Parrot");
PrintCollection(kyivHotelParrots, $"Тварини з іменем  \"Parrot\" у kyivHotelParrots");

// TODO: get all animals with name 'Parrot' from romashkaHotel
var romashkaHotelParrots = romashkaHotel.OfType<IAnimal>().Where(x => x.Name == "Parrot");
PrintCollection(romashkaHotelParrots, $"Тварини з іменем  \"Parrot\" у romashkaHotel");

// TODO: extend animals entity to have a property 'Age' and sort animals by age

#region Домашка
//додати сортування тварин за віком 
var sortedAnimals = genericHotel.OrderBy(x => x.Age);
PrintCollection(sortedAnimals, $"genericHotel тварини отсортовані по Age");

/*
 * Чисто эксперимент. Не обращать внимание. 
 * Эксперимент показывает когда именно задействуется интерфейс IComparable<Cat>
 * var cats1 = new List<Cat>
{
    {animalFactory.CreateCat("animalName", null, 10, Color.Navy)} ,
    {animalFactory.CreateCat("animalName1", null, 10, Color.Navy)} ,
    {animalFactory.CreateCat("animalName2", null, 10, Color.Navy)} ,
};
sortedAnimals = cats1.OrderBy(x => x);
PrintCollection(sortedAnimals, $"genericHotel Коти отсортованнык как коты");*/


sortedAnimals = kyivHotel.OrderBy(x => x.Age);
PrintCollection(sortedAnimals, $"kyivHotel тварини отсортовані  по Age");
sortedAnimals = romashkaHotel.OfType<IAnimal>().OrderBy(x => x.Age);
PrintCollection(sortedAnimals, $"romashkaHotel тварини отсортовані  по Age");

Console.WriteLine("Фільтрація тварин по імені власника");

//отримати всіх тварин, у яких власники мають ім'я (вводимо із клавіатури, або обираємо його випадковим чином)
var ownerFilter = "Jane";
Console.WriteLine("Введіть ім'я власника");
ownerFilter = Console.ReadLine();
var ownerAnimals = genericHotel.Where(x => x.Owner?.Name == ownerFilter);
PrintCollection(ownerAnimals, $"Тварини власника {ownerFilter} у genericHotel");
ownerAnimals = kyivHotel.Where(x => x.Owner?.Name == ownerFilter);
PrintCollection(ownerAnimals, $"Тварини власника {ownerFilter} у kyivHotel");
ownerAnimals = romashkaHotel.OfType<IAnimal>().Where(x => x.Owner?.Name == ownerFilter);
PrintCollection(ownerAnimals, $"Тварини власника {ownerFilter} у romashkaHotel");

#endregion


