using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {

        }


        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            Animal currentAnimal = ((Animal)animal);
            currentAnimal.Happiness -= 5;
            if (currentAnimal.IsChipped)
            {
                throw new ArgumentException($"{currentAnimal.Name} is already chipped");
            }
            currentAnimal.IsChipped = true;
            currentAnimal.ProcedureTime -= procedureTime;

            if (!procedureHistory.ContainsKey(this))
            {
                procedureHistory.Add(this, new List<Animal>());
            }
            procedureHistory[this].Add(currentAnimal);
        }
    }
}
