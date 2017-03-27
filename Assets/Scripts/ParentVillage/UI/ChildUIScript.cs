using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour {

    private Animator animator;
    private static GameObject dataDialog;

    public Child Child;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        if (dataDialog == null)
        {
            dataDialog = GameObject.Find("DataDialog");
            dataDialog.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) &&
            !GetComponent<Button>().GetComponent<Collider2D>().bounds.Contains(Input.mousePosition))
        {
            animator.SetBool("Animate", false);
            dataDialog.SetActive(false);
        }
    }

    public void Animate()
    {
        dataDialog.SetActive(true);
        dataDialog.GetComponent<DataDialogScript>().Show(Child);
        animator.SetBool("Animate", true);
    }
}
