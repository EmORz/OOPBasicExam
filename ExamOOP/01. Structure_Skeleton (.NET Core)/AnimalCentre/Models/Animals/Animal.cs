using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;

        protected Animal(string name, int happiness, int energy, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }
    
        public int Happiness
        {
            get { return happiness; }
            set
            {

                if (value<0 || value>100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value> 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime { get;  set; }

        public string Owner { get;  set; }

        public bool IsAdopt { get;  set; }

        public bool IsChipped { get;  set; }

        public bool IsVaccinated { get;  set; }
    }
}
