using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToSceneScript : MonoBehaviour {

    public string SceneName;
    public float Countdown = -1;

    private float currentTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (Countdown > 0 && currentTime > Countdown)
        {
            ForceTransition();
        }
	}

    public void ForceTransition()
    {
        SceneManager.LoadScene(SceneName);
    }
}
