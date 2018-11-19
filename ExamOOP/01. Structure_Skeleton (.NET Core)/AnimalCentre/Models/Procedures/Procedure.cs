using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Dictionary<Procedure, List<Animal>> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new Dictionary<Procedure, List<Animal>>();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {            
            if (((Animal)animal).ProcedureTime<procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var procedure in procedureHistory)
            {
                sb.AppendLine($"{procedure.Key}");
                foreach (var animals in procedure.Value)
                {
                    sb.AppendLine($"   - {animals.Name} - Happiness: {animals.Happiness} - Energy: {animals.Energy}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public IReadOnlyDictionary<Procedure, List<Animal>> ProcedureHistory => this.procedureHistory;

    }
}
