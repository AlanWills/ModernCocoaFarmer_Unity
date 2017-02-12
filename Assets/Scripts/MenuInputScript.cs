using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInputScript : MonoBehaviour {

    private int currentSelectedItem = 0;
    private float delay = 0;

	// Use this for initialization
	void Start ()
    {
        SelectItem(currentSelectedItem);
	}
	
	// Update is called once per frame
	void Update ()
    {
        delay += Time.deltaTime;

        if (delay > 0.25f)
        {
            float vertical = Input.GetAxis("Vertical");

            if (vertical > 0.9)
            {
                SelectItem(currentSelectedItem - 1);
            }
            else if (vertical < -0.9f)
            {
                SelectItem(currentSelectedItem + 1);
            }
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            transform.GetChild(currentSelectedItem).gameObject.GetComponent<Button>().onClick.Invoke();
        }
	}

    private void SelectItem(int newIndex)
    {
        int oldIndex = currentSelectedItem;

        while(newIndex < 0)
        {
            newIndex += transform.childCount;
        }

        currentSelectedItem = (newIndex % transform.childCount);

        Transform oldTransform = transform.GetChild(oldIndex);
        oldTransform.gameObject.GetComponentInChildren<Text>().color = new Color(0, 0, 0);

        Transform newTransform = transform.GetChild(currentSelectedItem);
        newTransform.gameObject.GetComponentInChildren<Text>().color = new Color(0, 0.5f, 0);

        delay = 0;
    }
}
