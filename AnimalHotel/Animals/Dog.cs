using System.Drawing;

namespace AnimalHotel.Animals;

public class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    // https://refactoring.guru/design-patterns/factory-method

    // Чисто шоб сховать и заставить создавать через фабричный метод  CreateDog? 
    private Dog() { }
    public static Dog CreateDog(string name, Owner owner, int age, Color color)
    {
        var result = new Dog();
        result.SetBaseProps(name, owner, age, color);
        return result;
    }

}
