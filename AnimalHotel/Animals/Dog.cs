using System.Drawing;

namespace AnimalHotel.Animals;

public class Dog : IAnimal
{
    public string Name { get; set; }
    public Owner Owner { get; private set; }

    public int Age { get; set; }

    public Color Color { get; set; }

    private Dog(string name, Owner owner, int age, Color color)
    {
        Name = name;
        Owner = owner;
        Age = age;
        Color = color;
    }

    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    public void Eat()
    {
        Console.WriteLine($"{nameof(Dog)} is eating");
    }


    // https://refactoring.guru/design-patterns/factory-method
    public static Dog CreateDog(string name, Owner owner, int age, Color color)
    {
        return new Dog(name, owner, age, color);
    }

    public override string ToString()
    {
        return $"Собак: {Name}, Вік: {Age},  {Color}, власник {Owner?.Name}";
    }
}
