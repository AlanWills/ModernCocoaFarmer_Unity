using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MathUtils
{
    public static float Clamp(float value, float min, float max)
    {
        if (value < min)
        {
            value = min;
        }

        if (value > max)
        {
            value = max;
        }

        return value;
    }
}