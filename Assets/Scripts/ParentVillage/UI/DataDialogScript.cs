using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataDialogScript : MonoBehaviour {

    public Child CurrentChild { get; private set; }

    public const string DataDialogName = "DataDialog";

    private Text childName;
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
        if (CurrentChild != null)
        {
            childName.text = CurrentChild.Name;
            healthBar.Value = CurrentChild.Health;
            safetyBar.Value = CurrentChild.Safety;
            educationBar.Value = CurrentChild.Education;
            happinessBar.Value = CurrentChild.Happiness;
        }
    }

    public void Show(Child child)
    {
        CurrentChild = child;

        childName.text = child.Name;
        healthBar.Value = child.Health;
        safetyBar.Value = child.Safety;
        educationBar.Value = child.Education;
        happinessBar.Value = child.Happiness;

        // Set active after setting values so UI is updated
        dataDialogUI.SetActive(true);
    }

    public void Hide()
    {
        CurrentChild = null;
        dataDialogUI.SetActive(false);
    }
}
