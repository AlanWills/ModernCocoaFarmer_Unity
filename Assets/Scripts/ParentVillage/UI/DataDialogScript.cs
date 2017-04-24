using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDialogScript : MonoBehaviour
{
    public const string DataDialogName = "DataDialog";

    private Text childName;
    private Text childLocation;
    private BarScript healthBar;
    private BarScript safetyBar;
    private BarScript educationBar;
    private BarScript happinessBar;

    private EventDialogScript eventDialog;
    private GameObject dataDialogUI;

    private const float Timer = 4;
    private float currentTimer = 0;
    private bool shown = false;

    // Use this for initialization
    void Awake ()
    {
        eventDialog = GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>();
        dataDialogUI = GameObject.Find(DataDialogName + "UI");
        childName = GameObject.Find("ChildName").GetComponent<Text>();
        childLocation = GameObject.Find("ChildLocation").GetComponent<Text>();
        healthBar = GameObject.Find("HealthBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        safetyBar = GameObject.Find("SafetyBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        educationBar = GameObject.Find("EducationBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
        happinessBar = GameObject.Find("HappinessBar").GetComponentInChildren(typeof(BarScript)) as BarScript;
    }

    private void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update ()
    {
        Child currentSelectedChild = ChildManager.SelectedChild;

        if (currentSelectedChild != null)
        {
            childName.text = currentSelectedChild.Name;
            childLocation.text = currentSelectedChild.BuildingType == BuildingType.Idle ? "" : currentSelectedChild.BuildingType.ToString();
            healthBar.Value = currentSelectedChild.Health;
            safetyBar.Value = currentSelectedChild.Safety;
            educationBar.Value = currentSelectedChild.Education;
            happinessBar.Value = currentSelectedChild.Happiness;
        }

        if (shown && !eventDialog.DialogOpen)
        {
            currentTimer += TimeManager.DeltaTime;
            if (currentTimer > Timer)
            {
                ChildManager.DeselectChild(ChildManager.SelectedChild);
                Hide();
            }
        }
    }

    public void Show(Child child)
    { 
        childName.text = child.Name;
        childLocation.text = child.BuildingType == BuildingType.Idle ? "" : child.BuildingType.ToString();
        healthBar.Value = child.Health;
        safetyBar.Value = child.Safety;
        educationBar.Value = child.Education;
        happinessBar.Value = child.Happiness;

        // Set active after setting values so UI is updated
        dataDialogUI.SetActive(true);
        shown = true;
    }

    public void Hide()
    {
        currentTimer = 0;
        shown = false;
        dataDialogUI.SetActive(false);
    }
}
