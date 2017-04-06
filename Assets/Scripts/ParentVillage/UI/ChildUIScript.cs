using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour {

    private Animator animator;
    private static DataDialogScript dataDialog;

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
        animator = GetComponent<Animator>();
	}
    
    public void Select()
    {
        ChildManager.SelectChild(Child);
        //dataDialog.GetComponent<DataDialogScript>().Show(Child);
    }

    private void ChildManager_ChildSelected(Child child)
    {
        animator.SetBool("Animate", child == Child);
    }
}
