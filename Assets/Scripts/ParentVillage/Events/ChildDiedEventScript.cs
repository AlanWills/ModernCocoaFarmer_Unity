using UnityEngine;

public class ChildDiedEventScript : EventScript
{
    public override string Name
    {
        get { return "Child Died"; }
    }

    public override string Description
    {
        get
        {
            return childThatDied.Name + " has died.";
        }
    }
    
    protected override string OnShowAudioClipPath { get { return "Audio/Death"; } }

    private Child childThatDied;
    
    public ChildDiedEventScript(Child child)
    {
        childThatDied = child;
    }

    protected override void OnNo()
    {
        base.OnNo();

        GameObject.Find("Graves").GetComponent<GraveCreatorScript>().CreateGrave();
    }
}