using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManagerUIScript : MonoBehaviour {

    public GameObject ChildUI;

    private List<GameObject> childUIs = new List<GameObject>();
    private const float Spacing = 80;

	// Use this for initialization
	void Start ()
    {
        ChildManager.ChildAdded += ChildManager_ChildAdded;
        ChildManager.ChildRemoved += ChildManager_ChildRemoved;
        ChildManager.ChildGraduated += ChildManager_ChildGraduated;
    }

    void Update()
    {
        ChildManager.Update();
    }

    private void ChildManager_ChildAdded(Child child)
    {
        GameObject ui = Instantiate(ChildUI, transform, false);
        ui.GetComponent<ChildUIScript>().Child = child;
        ui.transform.localPosition = new Vector3(Spacing * (ChildManager.ChildCount - 1), 0, 0);

        childUIs.Add(ui);
    }

    private void ChildManager_ChildRemoved(Child child)
    {
        if (child.Health <= 0)
        {
            GameObject.Find(EventDialogScript.EventDialogName).GetComponent<EventDialogScript>().QueueEvent(new ChildDiedEventScript(child));
        }

        RemoveChildUI(child);
    }

    private void ChildManager_ChildGraduated(Child child)
    {
        RemoveChildUI(child);
    }

    private void RemoveChildUI(Child child)
    {
        GameObject childUIToDestroy = childUIs.Find(x => x.GetComponent<ChildUIScript>().Child == child);
        childUIs.Remove(childUIToDestroy);
        Destroy(childUIToDestroy);

        // Fixup the positions of the other UI
        for (int i = 0; i < childUIs.Count; ++i)
        {
            childUIs[i].transform.localPosition = new Vector3(Spacing * i, 0, 0);
        }
    }

    private void OnDestroy()
    {
        ChildManager.ChildAdded -= ChildManager_ChildAdded;
        ChildManager.ChildRemoved -= ChildManager_ChildRemoved;
        ChildManager.ChildGraduated -= ChildManager_ChildGraduated;
    }
}
