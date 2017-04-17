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

    private GameObject dataDialogUI;

    // Use this for initialization
    void Awake ()
    {
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
        dataDialogUI.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        Child currentSelectedChild = ChildManager.SelectedChild;

        if (currentSelectedChild != null)
        {
            childName.text = currentSelectedChild.Name;
            childLocation.text = currentSelectedChild.BuildingType.ToString();
            healthBar.Value = currentSelectedChild.Health;
            safetyBar.Value = currentSelectedChild.Safety;
            educationBar.Value = currentSelectedChild.Education;
            happinessBar.Value = currentSelectedChild.Happiness;
        }
    }

    public void Show(Child child)
    { 
        childName.text = child.Name;
        childLocation.text = child.BuildingType.ToString();
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
