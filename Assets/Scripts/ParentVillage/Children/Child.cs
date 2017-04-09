using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Assertions;

public class Child : IData
{
    public delegate void LockedInHandler(Child child);

    public const float MaxEducation = 100;
    public const float MaxHealth = 100;
    public const float MaxSafety = 100;
    public const float MaxHappiness = 100;

    public float Education { get; private set; }

    public float Health { get; private set; }

    public float Safety { get; private set; }

    public float Happiness { get; private set; }

    public bool IsSelected { get; set; }

    public BuildingType BuildingType { get; private set; }

    public event LockedInHandler OnLockedIn;

    public const string Surname = "Keita";
    public string Name { get; private set; }

    public Child(string name)
    {
        BuildingType = BuildingType.Idle;
        Name = name;
        Education = 0;
        Health = MaxHealth;
        Safety = MaxSafety;
        Happiness = MaxHappiness;
    }

    public void Apply(DataPacket data)
    {
        Education = MathUtils.Clamp(Education + data.Education, 0, MaxEducation);
        Health = MathUtils.Clamp(Health + data.Health, 0, MaxHealth);
        Safety = MathUtils.Clamp(Safety + data.Safety, 0, MaxSafety);
        Happiness = MathUtils.Clamp(Happiness + data.Happiness, 0, MaxHappiness);
    }

    public void LockIn(BuildingType buildingType)
    {
        Assert.AreEqual(BuildingType.Idle, BuildingType);
        BuildingType = buildingType;

        if (OnLockedIn != null)
        {
            OnLockedIn.Invoke(this);
        }
    }
}