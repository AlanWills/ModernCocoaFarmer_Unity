using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct DataPacket : IData
{
    public float Education { get; private set; }
    public float Health { get; private set; }
    public float Safety { get; private set; }
    public float Happiness { get; private set; }

    public DataPacket(
        float education,
        float health,
        float safety,
        float happiness)
    {
        Education = education;
        Health = health;
        Safety = safety;
        Happiness = happiness;
    }
}