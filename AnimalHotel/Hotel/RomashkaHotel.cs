using System.Collections;
using AnimalHotel.Animals;

namespace AnimalHotel.Hotel;

public class RomashkaHotel : IEnumerable
{
    private object[] _animals = new object[4];
    private int _count = 0;
    private int _capacity = 4;

    public void FeedAnimals()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Eat();
            }
        }
    }

    public void PutAnimalsToSleep()
    {
        foreach (var animal in _animals)
        {
            if (animal is IAnimal iAnimal)
            {
                iAnimal.Sleep();
            }
        }
    }

    // Метод изменил. Вместо     public void AddAnimal(object animal)
    public void AddAnimal(IAnimal animal)
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
            if (animal is IAnimal iAnimal) // Проверка в принципе уже лишняя. Засунуть можно только через AddAnimal(IAnimal animal)
            {
                Console.WriteLine(iAnimal.Name);
            }
        }
    }

    public object this[int index]
    {
        //index может выйти за диапазон
        get
        {
            if (index >= 0 && index < _count)
                return _animals[index];
            else
                throw new ArgumentException($"index {index} вышел за пределы допустимого диапазона");
        }
        set => _animals[index] = value;
    }

    public IEnumerator GetEnumerator()
    {
        for (var i = 0; i < _count; i++)
        {
            yield return _animals[i];
        }
    }
}
