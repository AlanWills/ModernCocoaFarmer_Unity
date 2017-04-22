using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour
{
    public Sprite HomeIcon;
    public Sprite SchoolIcon;
    public Sprite WorkIcon;
    public Sprite MosqueIcon;
    public Sprite HospitalIcon;
    public Sprite MarketIcon;

    private Animator animator;
    private static DataDialogScript dataDialog;
    private float secondTimer = 0;

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
	}

    private void Update()
    {
        secondTimer += Time.deltaTime;

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

    public void ToggleSelect()
    {
        if (Child.IsSelected)
        {
            ChildManager.DeselectChild(Child);
        }
        else
        {
            ChildManager.SelectChild(Child);
        }
    }
    
    private void ChildManager_ChildSelected(Child child)
    {
        // Only deal with the data dialog if this ChildUI's child is the selected one
        if (child == Child)
        {
            dataDialog.Show(Child);
            animator.SetBool("Animate", true);
        }
        else
        {
            animator.SetBool("Animate", false);
        }
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
