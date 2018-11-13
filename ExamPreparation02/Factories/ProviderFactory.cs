using ExamPreparation02.Units.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPreparation02.Factories
{
   public class ProviderFactory
    {
        public Provider CreateProvider(List<string> arguments)
        {
            var type = arguments[0];
            type = type.ToLower();
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            switch (type)
            {
                case "solar":
                    return new SolarProvider(id,oreOutput);
                case "pressure":
                    return new PressureProvider(id,oreOutput);
                default:
                    throw new ArgumentException("Invalid provider");
            }
        }
    }
}
