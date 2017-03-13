using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEventDialogScript : MonoBehaviour {

    public RandomEventScript RandomEvent { get; private set; }

    private Text descriptionUI;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEvent(RandomEventScript eventScript)
    {
        RandomEvent = eventScript;

        if (descriptionUI == null)
        {
            descriptionUI = GameObject.Find("Description").GetComponent<Text>();
        }
        descriptionUI.text = RandomEvent.Description;
    }

    public void Yes()
    {
        RandomEvent.Yes();
    }

    public void No()
    {
        RandomEvent.No();
    }
}
