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
    
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) &&
            !GetComponent<Button>().GetComponent<Collider2D>().bounds.Contains(Input.mousePosition))
        {
            animator.SetBool("Animate", false);
            dataDialog.Hide();
        }
    }

    public void Animate()
    {
        dataDialog.GetComponent<DataDialogScript>().Show(Child);
        animator.SetBool("Animate", true);
    }
}
