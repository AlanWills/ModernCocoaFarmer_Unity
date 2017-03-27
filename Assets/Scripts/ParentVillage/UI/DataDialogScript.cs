using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDialogScript : MonoBehaviour {

    public const string DataDialogName = "DataDialog";

    private BarScript healthBar;
    private BarScript safetyBar;
    private BarScript educationBar;
    private BarScript happinessBar;

    private GameObject dataDialogUI;

    // Use this for initialization
    void Awake ()
    {
        dataDialogUI = GameObject.Find(DataDialogName + "UI");
        healthBar = GameObject.Find("HealthBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        safetyBar = GameObject.Find("SafetyBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        educationBar = GameObject.Find("EducationBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        happinessBar = GameObject.Find("HappinessBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
    }

    private void Start()
    {
        dataDialogUI.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Show(Child child)
    {
        healthBar.Value = child.Health;
        safetyBar.Value = child.Safety;
        educationBar.Value = child.Education;
        happinessBar.Value = child.Happiness;

        // Set active after setting values so UI is updated
        dataDialogUI.SetActive(true);
    }

    public void Hide()
    {
        dataDialogUI.SetActive(false);
    }
}
