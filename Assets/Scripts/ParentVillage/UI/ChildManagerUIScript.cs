using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManagerUIScript : MonoBehaviour {

    public GameObject ChildUI;

	// Use this for initialization
	void Start ()
    {
        ChildManager.ChildAdded += ChildManager_ChildAdded;
    }

    private void ChildManager_ChildAdded(Child child)
    {
        GameObject ui = Instantiate(ChildUI, transform, false);
        ui.GetComponent<ChildUIScript>().Child = child;
        ui.transform.localPosition = new Vector3(100 * (ChildManager.ChildCount - 1), 0, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
