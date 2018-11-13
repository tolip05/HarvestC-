using System;
using System.Collections.Generic;
using System.Text;


public abstract class Unit
{
    public abstract string Type { get; }
    private string id;

    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => id;
        private set
        {
            id = value;
        }
    }
}

