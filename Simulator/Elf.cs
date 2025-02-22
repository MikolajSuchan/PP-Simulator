﻿using System.Text.Json.Serialization;

namespace Simulator.Maps;

public class Elf : Creature
{
    private int _singCounter = 0;
    private int _agility;

    [JsonIgnore]
    public override char Symbol => 'E';

    public Elf()
    {
    }
    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name,level)
    {
        Name = name;
        Level = level;
        Agility = agility;
    }

    public int Agility
    {
        get => _agility;
        init => _agility = Validator.Limiter(value, 0, 10);
    }

    [JsonIgnore]
    public override int Power => Level * 8 + Agility * 2;

    [JsonIgnore]
    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    }

    public void Sing()
    {
        _singCounter++;
        if (_singCounter % 3 == 0)
        {
            _agility++;
        }
    }
}