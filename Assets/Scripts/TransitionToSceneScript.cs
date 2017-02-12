using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToSceneScript : MonoBehaviour {

    public string SceneName;
    public float Countdown = -1;
    public string AxisToTrigger;

    private float currentTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Countdown > 0)
        {
            currentTime += Time.deltaTime;

            if (currentTime > Countdown)
            {
                ForceTransition();
            }
        }
        else if (!string.IsNullOrEmpty(AxisToTrigger) && Input.GetAxis(AxisToTrigger) > 0)
        {
            ForceTransition();
        }
	}

    public void ForceTransition()
    {
        SceneManager.LoadScene(SceneName);
    }
}
