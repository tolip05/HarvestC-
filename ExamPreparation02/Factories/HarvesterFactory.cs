using ExamPreparation02.Units.Harvesters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation02.Factories
{
   public class HarvesterFactory
    {
        public Harvester CreateHarvester(List<string> arguments)
        {
            var type = arguments[0];
            type = type.ToLower();
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            var energyRequarement = double.Parse(arguments[3]);
            switch (type)
            {
                case "hammer":
                    return new HammerHarvester(id,oreOutput,energyRequarement);
                case "sonic":
                    return new SonicHarvester(id, oreOutput, energyRequarement,int.Parse(arguments[4]));
                default:
                    throw new ArgumentException("Invalid Harvest");
            }
        }
    }
}
