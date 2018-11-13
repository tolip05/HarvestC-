using ExamPreparation02.Units.Harvesters;
using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public override string Type => "Sonic";
    private int sonicFactor;
    public SonicHarvester(string id, double oreOutput, double energyRequerement,int sonicFactor) 
        : base(id, oreOutput, energyRequerement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequerement = this.EnergyRequerement / this.SonicFactor;
    }

    public int SonicFactor
    {
        get => sonicFactor;
        private set
        {
            sonicFactor = value;
        }
    }
}

