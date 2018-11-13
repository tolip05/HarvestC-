using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation02.Units.Providers
{
    public abstract class Provider : Unit
    {
        private double energyOutput;
        protected Provider(string id,double energyOutput) 
            : base(id)
        {
            this.EnergyOutput = energyOutput;
        }

        public double EnergyOutput
        {
            get => energyOutput;
            private set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Provider is not registered,because of is't energyOutput");
                }
                energyOutput = value;
            }
        }
        public override string ToString()
        {
            return $"{Type} Provider - {Id}" + Environment.NewLine +
                   $"Energy Output: {EnergyOutput}";
        }
    }
}
