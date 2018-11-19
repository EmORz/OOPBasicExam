using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public Vaccinate()
        {
        }
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            Animal currentAnimal = ((Animal)animal);
            currentAnimal.IsVaccinated = true;
            currentAnimal.Energy -= 8;
            ((Animal)animal).ProcedureTime -= procedureTime;

            if (!procedureHistory.ContainsKey(this))
            {
                procedureHistory.Add(this, new List<Animal>());
            }
            procedureHistory[this].Add(currentAnimal);


        }
    }
}
