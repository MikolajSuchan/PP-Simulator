﻿using Simulator.Maps;
using System.Text.Json.Serialization;

namespace Simulator;

public class Orc: Creature
{
    private int _huntCounter = 0;
    private int _rage;

    [JsonIgnore]
    public override char Symbol => 'O';

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name,level)
    {
        Name = name;
        Level = level;
        Rage = rage; 
    }

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }
    [JsonIgnore]
    public override int Power => Level * 7 + Rage * 3;
    [JsonIgnore]
    public override string Info => $"{Name} [{Level}][{Rage}]";

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }

    public void Hunt()
    {
        _huntCounter++;
        if (_huntCounter % 2 == 0)
        {
            _rage++;
        }
    }
}
