using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour
{
    private Animator animator;
    private static DataDialogScript dataDialog;
    private float secondTimer = 0;
    private float timeSinceLastClicked = 0;

    public Child Child { get; set; }

    // Use this for initialization
    private void Awake()
    {
        if (dataDialog == null)
        {
            dataDialog = GameObject.Find(DataDialogScript.DataDialogName).GetComponent<DataDialogScript>();
        }
    }
    
	void Start ()
    {
        ChildManager.ChildSelected += ChildManager_ChildSelected;
        ChildManager.ChildDeselected += ChildManager_ChildDeselected;
        animator = GetComponent<Animator>();
        GetComponentInChildren<Text>().text = Child.Name;
	}

    private void Update()
    {
        secondTimer += TimeManager.DeltaTime;
        timeSinceLastClicked += TimeManager.DeltaTime;

        if (secondTimer >= 1)
        {
            Child.Apply(
                new DataPacket(
                0,
                -ChildManager.ChildDegredation / TimeManager.SecondsPerYear,
                0,
                -ChildManager.ChildDegredation / TimeManager.SecondsPerYear));

            secondTimer = 0;
        }
    }

    public void Click()
    {
        bool doubleClicked = timeSinceLastClicked < 0.5f;

        if (Child.IsSelected && !doubleClicked)
        {
            // If we double click, we must always select the child otherwise the data dialog will have nothing to show 
            ChildManager.DeselectChild(Child);
        }
        else
        {
            ChildManager.SelectChild(Child);
        }

        if (doubleClicked)
        {
            dataDialog.Show(Child);
        }
        
        timeSinceLastClicked = 0;
    }
    
    private void ChildManager_ChildSelected(Child child)
    {
        // Only deal with the data dialog if this ChildUI's child is the selected one
        animator.SetBool("Animate", child == Child);
    }

    private void ChildManager_ChildDeselected(Child child)
    {
        // Only deal with the data dialog if this ChildUI's child is the selected one
        if (child == Child)
        {
            dataDialog.Hide();
            animator.SetBool("Animate", false);
        }
    }
    
    public void OnDestroy()
    {
        ChildManager.ChildSelected -= ChildManager_ChildSelected;
        ChildManager.ChildDeselected -= ChildManager_ChildDeselected;
    }
}
