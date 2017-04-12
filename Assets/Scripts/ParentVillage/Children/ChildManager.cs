using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

public static class ChildManager
{
    public delegate void ChildAddedHandler(Child child);
    public delegate void ChildRemovedHandler(Child child);
    public delegate void ChildSelectedHandler(Child child);

    public static event ChildAddedHandler ChildAdded;
    public static event ChildRemovedHandler ChildRemoved;
    public static event ChildSelectedHandler ChildSelected;
    public static event ChildSelectedHandler ChildDeselected;

    public const int MaxChildCount = 7;
    public static int ChildCount { get { return Children.Count; } }
    public static Child SelectedChild { get { return Children.Find(x => x.IsSelected); } }

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
        "Salif",
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
        RemoveChild(Children[index]);
    }

    public static void RemoveChild(Child child)
    {
        DeselectChild(child);
        Children.Remove(child);

        if (ChildRemoved != null)
        {
            ChildRemoved.Invoke(child);
        }

        if (ChildCount == 0)
        {
            SceneManager.LoadScene("LoseMenu");
        }
    }

    public static Child GetChild(int index)
    {
        return Children[index];
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

    public static void DeselectChild(Child child)
    {
        child.IsSelected = false;

        if (ChildDeselected != null)
        {
            ChildDeselected.Invoke(child);
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