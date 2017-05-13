using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct DataPacket : IData
{
    public float Health { get; private set; }
    public float Safety { get; private set; }
    public float Education { get; private set; }
    public float Happiness { get; private set; }

    public DataPacket(
        float health,
        float safety,
        float education,
        float happiness)
    {
        Health = health;
        Safety = safety;
        Education = education;
        Happiness = happiness;
    }
}