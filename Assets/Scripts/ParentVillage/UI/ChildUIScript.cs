using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour {

    private Animator animator;
    private static DataDialogScript dataDialog;

    public Child Child { get; set; }

    private float timeHeld = 0;

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
        animator = GetComponent<Animator>();
	}

    public void Update()
    {
        if (Child.IsSelected)
        {
            if (Input.GetMouseButton(0))
            {
                timeHeld += Time.deltaTime;
                if (timeHeld > 0.5f)
                {
                    dataDialog.GetComponent<DataDialogScript>().Show(Child);
                }
            }
            else
            {
                timeHeld = 0;
                dataDialog.GetComponent<DataDialogScript>().Hide();
            }
        }
    }   
     
    public void Select()
    {
        ChildManager.SelectChild(Child);
    }

    private void ChildManager_ChildSelected(Child child)
    {
        timeHeld = 0;
        animator.SetBool("Animate", child == Child);
    }
}
