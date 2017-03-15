using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ChildManager
{
    private static List<Child> Children = new List<Child>()
    {
        new Child()
    };

    public static void ApplyEvent(DataPacket data)
    {
        foreach (Child child in Children)
        {
            child.Apply(data);
        }
    }
}