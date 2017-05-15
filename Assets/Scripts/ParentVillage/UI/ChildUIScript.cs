using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour
{
    private Animator animator;
    private Text childName;
    private Text childLocation;
    private GameObject border;
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
        childName = transform.FindChild("Name").GetComponent<Text>();
        childName.text = Child.Name;
        childLocation = transform.FindChild("Location").GetComponent<Text>();
        childLocation.text = "";
        border = transform.FindChild("Border").gameObject;
        border.SetActive(false);
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

        childLocation.text = childLocation.text = Child.BuildingType == BuildingType.Idle ? "" : Child.BuildingType.ToString();
    }

    public void Click()
    {
        bool doubleClicked = timeSinceLastClicked < 0.5f;

        if (Child.IsSelected && !doubleClicked)
        {
            ChildManager.DeselectChild(Child);
        }
        else
        {
            // If we double click, we must always select the child otherwise the data dialog will have nothing to show 
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
        // This is called when we call the ChildManager.SelectChild, NOT when the Child's IsSelected flag is changed
        // Since each UI subscribes we have to set the UI based on whether this UI's child was selected
        bool isThisChild = child == Child;
        childName.color = isThisChild ? new Color(0, 0.5f, 0) : Color.black;
        childLocation.color = childName.color;
        border.SetActive(isThisChild);
        animator.SetBool("Animate", isThisChild);
    }

    private void ChildManager_ChildDeselected(Child child)
    {
        // This is called when we call the ChildManager.DeselectChild, NOT when the Child's IsSelected flag is changed
        // Since each Child UI subscribes, we have to check the deselected child is this UI's child
        if (child == Child)
        {
            // Reset UI
            dataDialog.Hide();
            animator.SetBool("Animate", false);
            childName.color = Color.black;
            childLocation.color = childName.color;
            border.SetActive(false);
        }
    }
    
    public void OnDestroy()
    {
        ChildManager.ChildSelected -= ChildManager_ChildSelected;
        ChildManager.ChildDeselected -= ChildManager_ChildDeselected;
    }
}
