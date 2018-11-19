using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int capacityDefault = 10;
        private Dictionary<string, Animal> animals;

        public Hotel()
        {
            this.Capacity = capacityDefault;
            this.animals = new Dictionary<string, Animal>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyDictionary<string, Animal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        { 
            var currenrAnimal = ((Animal)animal);
            if (animals.Count>this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (animals.ContainsKey(currenrAnimal.Name))
            {
                throw new ArgumentException($"Animal {currenrAnimal.Name} already exist");
            }
            this.animals.Add(currenrAnimal.Name, currenrAnimal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            Animal currentAnimal = animals.FirstOrDefault(a => a.Key == animalName).Value;
            currentAnimal.Owner = owner;
            currentAnimal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
