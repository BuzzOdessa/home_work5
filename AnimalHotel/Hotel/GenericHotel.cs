using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class GenericHotel<TData> : IEnumerable<TData> where TData : IAnimal
{
    private int _count = 0;
    private int _capacity = 4;
    private TData[] _animals = new TData[4];

    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            animal.Eat();
        }
    }

    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            animal.Sleep();
        }
    }

    public void AddAnimal(TData animal)
    {
        if (animal == null)
            return;
        if (_count == _capacity)
        {
            _capacity *= 2;
            Array.Resize(ref _animals, _capacity);
        }

        _animals[_count++] = animal;
    }
    public void PrintAnimals()
    {
        foreach (var animal in _animals)
        {
            Console.WriteLine(animal.Name);
        }
    }

    public TData this[int index]
    {
        get => _animals[index];
        set => _animals[index] = value;
    }

    public IEnumerator<TData> GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
