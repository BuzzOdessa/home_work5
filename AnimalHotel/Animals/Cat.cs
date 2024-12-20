using System.Drawing;

namespace AnimalHotel.Animals;

public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }

    // Чисто шоб сховать и заставить создавать через фабричный метод  CreateCat? 
    private Cat() { }

    public static Cat CreateCat(string name, Owner owner, int age, Color color)
    {
        var result = new Cat();
        result.SetBaseProps(name, owner, age, color);
        return result;
    }
}
