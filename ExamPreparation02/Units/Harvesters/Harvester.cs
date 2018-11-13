using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation02.Units.Harvesters
{
   public abstract class Harvester : Unit
    {
        private double oreOutput;
        private double energyRequerement;

        protected Harvester(string id , double oreOutput,double energyRequerement) 
            : base(id)
        {
            this.OreOutput = oreOutput;
            this.EnergyRequerement = energyRequerement;
        }

        public double OreOutput
        {
            get => oreOutput;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Harvester is not registered,because of is't oreOutput");
                }
                oreOutput = value;
            }
        }

        public double EnergyRequerement
        {
            get => energyRequerement;
            protected set
            {
                if (value < 0 || value > 20000)
                {
                    throw new ArgumentException("Harvester is not registered,because of is't energyRequerement");
                }
                energyRequerement = value;
            }
            
        }
        public override string ToString()
        {
            return $"{Type} Harvester - {Id}" + Environment.NewLine +
                   $"Ore Output: {OreOutput}" + Environment.NewLine +
                   $"Energy Requirement: {EnergyRequerement}";
        }
    }
}
