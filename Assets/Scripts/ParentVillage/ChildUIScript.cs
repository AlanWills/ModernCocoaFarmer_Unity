using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ChildUIScript : MonoBehaviour {

    private Animator animator;
    private GameObject dataDialog;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        dataDialog = GameObject.Find("DataDialog");
        dataDialog.SetActive(false);
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

    public void ToggleAnimate()
    {
        dataDialog.SetActive(true);
        animator.SetBool("Animate", true);
    }
}
