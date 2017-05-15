using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllBuildingsClickedOnScript : MonoBehaviour
{
    private EventDialogScript eventDialog;
    private GiveBirthToChildrenScript giveBirthToChildren;

	// Use this for initialization
	void Start ()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        giveBirthToChildren = GetComponent<GiveBirthToChildrenScript>();
        giveBirthToChildren.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (SendChildToHospitalEventScript.ClickedOn &&
            SendChildToMarketEventScript.ClickedOn &&
            SendChildToMosqueEventScript.ClickedOn &&
            SendChildToSchoolEventScript.ClickedOn &&
            SendChildToWellEventScript.ClickedOn &&
            SendChildToWorkEventScript.ClickedOn &&
            UpgradeHouseEventScript.ClickedOn &&
            !eventDialog.DialogOpen)
        {
            giveBirthToChildren.enabled = true;
            enabled = false;
        }
	}
}
