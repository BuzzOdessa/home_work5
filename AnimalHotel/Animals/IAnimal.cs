namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    void Eat();

    public Owner Owner { get; }
    void Sleep()
    {
        Console.WriteLine($"{nameof(IAnimal)} is sleeping");
    }
}
