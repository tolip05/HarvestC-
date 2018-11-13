using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation02.Units.Providers
{
    public class SolarProvider : Provider
    {
        public override string Type => "Solar";
        public SolarProvider(string id, double energyOutput) 
            : base(id, energyOutput)
        {
        }
    }
}
