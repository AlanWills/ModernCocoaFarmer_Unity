using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Child : IData
{
    public float Education { get; private set; }

    public float Income { get; private set; }

    public float Health { get; private set; }

    public float Safety { get; private set; }

    public float Happiness { get; private set; }

    public void Apply(DataPacket data)
    {
        Education = MathUtils.Clamp(Education + data.Education, 0, 1);
        Income = MathUtils.Clamp(Income + data.Income, 0, 1);
        Health = MathUtils.Clamp(Health + data.Health, 0, 1);
        Safety = MathUtils.Clamp(Safety + data.Safety, 0, 1);
        Happiness = MathUtils.Clamp(Happiness + data.Happiness, 0, 1);
    }
}