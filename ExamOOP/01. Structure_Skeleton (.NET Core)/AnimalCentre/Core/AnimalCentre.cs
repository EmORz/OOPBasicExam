using AnimalCentre.Models;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        Hotel hotel;
        Chip chip = new Chip();
        Vaccinate vaccinate = new Vaccinate();
        Fitness fitness = new Fitness();
        Play play = new Play();
        DentalCare dentalCare = new DentalCare() ;
        NailTrim nailTrim = new NailTrim();

        private Dictionary<string, List<Animal>> history;
        protected SortedDictionary<string, List<string>> adopted;

        public string chiped = "Chip";
        public string vaccinated = "Vaccinate";
        public string fitnessed = "Fitness";
        public string played = "Play";
        public string dental = "DentalCare";
        public string nail = "NailTrim";


        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.history = new Dictionary<string, List<Animal>>();
            this.adopted = new SortedDictionary<string, List<string>>();
        }
        public void Print()
        {   

            foreach (var owner in adopted)
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            MethodForRegisterAnimal(type, name, energy, happiness, procedureTime);

            return $"Animal {name} registered successfully";
        }


        public string Chip(string name, int procedureTime)
        {

            CheckAnimalExist(name);
            Animal animal = GetAnimal(name);
            chip.DoService(animal, procedureTime);
            AddHistory(name, animal, chiped);

            return $"{name} had chip procedure";

        }


        public string Vaccinate(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            Animal animal = hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
            vaccinate.DoService(animal, procedureTime);
            AddHistory(name, animal, vaccinated);

            return $"{name} had vaccination procedure";

        }

        public string Fitness(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            Animal animal = GetAnimal(name);
            fitness.DoService(animal, procedureTime);
            AddHistory(name, animal, fitnessed);

            return $"{name} had fitness procedure";


        }

        public string Play(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            Animal animal = GetAnimal(name);
            play.DoService(animal, procedureTime);
            AddHistory(name, animal, played);

            return $"{name} was playing for {procedureTime} hours";

        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            Animal animal = GetAnimal(name);
            dentalCare.DoService(animal, procedureTime);
            AddHistory(name, animal, dental);

            return $"{name} had dental care procedure";

        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            Animal animal = GetAnimal(name);
            nailTrim.DoService(animal, procedureTime);
            AddHistory(name, animal, nail);
            return $"{name} had nail trim procedure";

        }

        public string Adopt(string animalName, string owner)
        {
            //Finds the animal with that name in the hotel and adopts it.
            CheckAnimalExist(animalName);
            Animal animal =  GetAnimal(animalName);
            hotel.Adopt(animalName, owner);
            if (!adopted.ContainsKey(owner))
            {
                adopted.Add(owner, new List<string>());
            }
            adopted[owner].Add(animalName);
            if (animal.IsChipped)
            {
                return $"{animal.Owner} adopted animal with chip";

            }
            else
            {
                return $"{animal.Owner} adopted animal without chip";

            }
        }

        public string History(string type)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(type);
            foreach (var animal in history[type])
            {
                stringBuilder.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
        //Inner private methods

        private Animal GetAnimal(string name)
        {
            return hotel.Animals.Values.FirstOrDefault(x => x.Name == name);
        }
        private void MethodForRegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Cat":
                    hotel.Accommodate(new Cat(name, happiness, energy, procedureTime));
                    break;
                case "Dog":
                    hotel.Accommodate(new Dog(name, happiness, energy, procedureTime));
                    break;
                case "Lion":
                    hotel.Accommodate(new Lion(name, happiness, energy, procedureTime));
                    break;
                case "Pig":
                    hotel.Accommodate(new Pig(name, happiness, energy, procedureTime));
                    break;
            }
        }
        private void CheckAnimalExist(string name)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }

        private void AddHistory(string name, Animal animal, string type)
        {
            if (!history.ContainsKey(type))
            {
                history.Add(type, new List<Animal>());
            }
            history[type].Add(animal);
        }
    }
}
