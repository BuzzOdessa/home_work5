using System.Drawing;

namespace AnimalHotel.Animals;
public class Animal : IAnimal
{
    public string Name { get; set; } = string.Empty;
    public Owner? Owner { get; protected set; }

    public int Age { get; set; }
    public Color Color { get; set; }

    protected void SetBaseProps(string name, Owner owner, int age, Color color)
    {
        Name = name;
        Owner = owner;
        Age = age;
        Color = color;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {Name}, Вік: {Age},  {Color}, власник {Owner?.Name}";
    }

    public virtual void Eat()
    {
        Console.WriteLine($"{GetType().Name} is eating");
    }

    public virtual void Sleep()
    {
        Console.WriteLine($"{GetType().Name} is sleeping");
    }
}
