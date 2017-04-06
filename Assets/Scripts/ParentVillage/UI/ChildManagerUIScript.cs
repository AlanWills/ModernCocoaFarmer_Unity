using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManagerUIScript : MonoBehaviour {

    public GameObject ChildUI;

    private List<GameObject> childUIs = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        ChildManager.ChildAdded += ChildManager_ChildAdded;
        ChildManager.ChildRemoved += ChildManager_ChildRemoved; ;
    }

    private void ChildManager_ChildAdded(Child child)
    {
        GameObject ui = Instantiate(ChildUI, transform, false);
        ui.GetComponent<ChildUIScript>().Child = child;
        ui.transform.localPosition = new Vector3(100 * (ChildManager.ChildCount - 1), 0, 0);

        childUIs.Add(ui);
    }

    private void ChildManager_ChildRemoved(Child child)
    {
        Destroy(childUIs.Find(x => x.GetComponent<ChildUIScript>().Child == child));

        // Fixup the positions of the other UI
        for (int i = 0; i < childUIs.Count; ++i)
        {
            childUIs[i].transform.localPosition = new Vector3(100 * i, 0, 0);
        }
    }
}
