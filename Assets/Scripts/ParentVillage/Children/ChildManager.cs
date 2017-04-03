using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ChildManager
{
    public delegate void ChildAddedHandler(Child child);

    public static event ChildAddedHandler ChildAdded;
    
    // Add fixed 7 child cap - this is the average in real life

    public static int ChildCount { get { return Children.Count; } }

    private static List<Child> Children = new List<Child>();

    public static void AddChild()
    {
        Child child = new Child();
        Children.Add(child);

        if (ChildAdded != null)
        {
            ChildAdded.Invoke(child);
        }
    }

    public static void ApplyEvent(DataPacket data)
    {
        foreach (Child child in Children)
        {
            child.Apply(data);
        }
    }
}