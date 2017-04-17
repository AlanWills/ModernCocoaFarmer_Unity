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
    private Image buildingTypeIcon;

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
        Child.OnLockedIn += Child_OnLockedIn;
        animator = GetComponent<Animator>();
        buildingTypeIcon = GameObject.Find("BuildingTypeIcon").GetComponent<Image>();
        Child_OnLockedIn(Child);
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

    private void Child_OnLockedIn(Child child)
    {
        buildingTypeIcon.gameObject.SetActive(true);

        switch (child.BuildingType)
        {
            case BuildingType.Home:
                buildingTypeIcon.sprite = HomeIcon;
                break;

            case BuildingType.Work:
                buildingTypeIcon.sprite = WorkIcon;
                break;

            case BuildingType.School:
                buildingTypeIcon.sprite = SchoolIcon;
                break;

            case BuildingType.Hospital:
                buildingTypeIcon.sprite = HospitalIcon;
                break;

            case BuildingType.Mosque:
                buildingTypeIcon.sprite = MosqueIcon;
                break;

            case BuildingType.Market:
                buildingTypeIcon.sprite = MarketIcon;
                break;

            case BuildingType.Idle:
            default:
                buildingTypeIcon.gameObject.SetActive(false);
                buildingTypeIcon.sprite = null;
                break;
        }
    }

    public void OnDestroy()
    {
        ChildManager.ChildSelected -= ChildManager_ChildSelected;
        ChildManager.ChildDeselected -= ChildManager_ChildDeselected;
    }
}
