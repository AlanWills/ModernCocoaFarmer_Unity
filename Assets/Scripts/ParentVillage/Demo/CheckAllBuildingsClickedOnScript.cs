using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllBuildingsClickedOnScript : MonoBehaviour
{
    private EventDialogScript eventDialog;
    private GiveBirthToSecondChildScript giveBirthToSecondChild;

	// Use this for initialization
	void Start ()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        giveBirthToSecondChild = GetComponent<GiveBirthToSecondChildScript>();
        giveBirthToSecondChild.enabled = false;
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
            eventDialog.QueueEvent(new GiveBirthToChildEvent());
            giveBirthToSecondChild.enabled = true;
        }
	}
}
