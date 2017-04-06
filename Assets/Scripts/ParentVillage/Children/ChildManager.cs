using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ChildManager
{
    public delegate void ChildAddedHandler(Child child);
    public delegate void ChildRemovedHandler(Child child);
    public delegate void ChildSelectedHandler(Child child);

    public static event ChildAddedHandler ChildAdded;
    public static event ChildRemovedHandler ChildRemoved;
    public static event ChildSelectedHandler ChildSelected;

    public const int MaxChildCount = 7;
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

    public static void RemoveChild(int index)
    {
        Child child = Children[index];
        Children.RemoveAt(index);

        if (ChildRemoved != null)
        {
            ChildRemoved.Invoke(child);
        }
    }

    public static Child FindChild(Predicate<Child> predicate)
    {
        return Children.Find(predicate);
    }

    public static void SelectChild(Child child)
    {
        foreach (Child c in Children)
        {
            c.IsSelected = false;
        }

        child.IsSelected = true;

        if (ChildSelected != null)
        {
            ChildSelected.Invoke(child);
        }
    }

    public static void ApplyEventToAllChildren(DataPacket data)
    {
        foreach (Child child in Children)
        {
            child.Apply(data);
        }
    }
}