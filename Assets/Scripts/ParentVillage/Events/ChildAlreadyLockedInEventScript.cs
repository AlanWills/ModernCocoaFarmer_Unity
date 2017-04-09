using System;

public class ChildAlreadyLockedInEventScript : EventScript
{
    public override string Name
    {
        get { return "Child Busy"; }
    }

    public override string Description
    {
        get { return ChildManager.SelectedChild.Name + " is busy at " + lockedInBuildingType.ToString(); }
    }

    private BuildingType lockedInBuildingType;

    public ChildAlreadyLockedInEventScript(BuildingType buildingType)
    {
        lockedInBuildingType = buildingType;
    }
}