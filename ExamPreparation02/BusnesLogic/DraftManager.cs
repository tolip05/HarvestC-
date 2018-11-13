using ExamPreparation02.Factories;
using ExamPreparation02.Units.Harvesters;
using ExamPreparation02.Units.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamPreparation02.BusnesLogic
{
   public class DraftManager
    {
        private List<Harvester> harvesters;
        private List<Provider> providers;
        private HarvesterFactory harvestFactory;
        private ProviderFactory providerFactory;
        private string mode;
        private double totalEnergyStored;
        private double totalMineOre;

        public DraftManager()
        {
            this.harvesters = new List<Harvester>();
            this.providers = new List<Provider>();
            this.harvestFactory = new HarvesterFactory();
            this.providerFactory = new ProviderFactory();
            this.mode = "Full";
            this.totalEnergyStored = 0;
            this.totalMineOre = 0;
        
        }
        public string RegisterHarvester(List<string>arguments)
        {
            try
            {
                var harvester = this.harvestFactory.CreateHarvester(arguments);
                this.harvesters.Add(harvester);
                return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
            }
            catch (ArgumentException ex)
            {

                return ex.Message;
            }
        }
        public string RegisterProvider(List<string>arguments)
        {
            try
            {
                var provider = this.providerFactory.CreateProvider(arguments);
                this.providers.Add(provider);
                return $"Successfully registered {provider.Type} Provider - {provider.Id}";
            }
            catch (ArgumentException ex)
            {

                return ex.Message;
            }
        }
        public string Mode(List<string> arguments)
        {
            this.mode = arguments[0];
            return $"Successfully changed working mode to {mode} Mode";
        }
        public string Check(List<string>arguments)
        {
            string id = arguments[0];
            Unit unit = (Unit)harvesters.FirstOrDefault(h => h.Id == id) ?? providers.FirstOrDefault(p => p.Id == id);
            if (unit != null)
            {
                return unit.ToString();
            }
            else
            {
                return $"No element found with id - {id}.";
            }
        }
        public string Day()
        {
            double dayEnergyProvided = this.providers.Sum(p => p.EnergyOutput);
            this.totalEnergyStored += dayEnergyProvided;
            double dayEnergyRequaerd, dayMineOre;
            if (mode == "Full")
            {
                dayEnergyRequaerd = harvesters.Sum(h => h.EnergyRequerement);
                dayMineOre = harvesters.Sum(h => h.OreOutput);
            }
            else if (mode == "Half")
            {
                dayEnergyRequaerd = harvesters.Sum(h => h.EnergyRequerement) * 0.6;
                dayMineOre = harvesters.Sum(h => h.OreOutput) * 0.5;
            }
            else
            {
                dayEnergyRequaerd = 0;
                dayMineOre = 0;
            }
            if (totalEnergyStored >= dayEnergyRequaerd)
            {
                totalMineOre += dayMineOre;
                totalEnergyStored -= dayEnergyRequaerd;
            }
            return "A day has passed." + Environment.NewLine +
                $"Energy Provided: {dayEnergyProvided}" + Environment.NewLine +
                $"Olumbus Ore Mined: {dayMineOre}";
        }
        public string ShutDown()
        {
            return "System ShutDown" + Environment.NewLine +
                $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
                $"Total Mined Flumbus: {totalMineOre}";
        }
    }
}
