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

    private static List<string> names = new List<string>()
    {
        "Adama",
        "Oumar",
        "Mohamed",
        "Ousmane",
        "Mamadou",
        "Bintou",
        "Mariam",
        "Sali",
    };

    public static void AddChild()
    {
        List<string> allFreeNames = names.Where(x => !Children.Exists(y => y.Name == x)).ToList();

        Random random = new Random();
        string freeName = allFreeNames[random.Next(0, allFreeNames.Count)];

        Child child = new Child(freeName);
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