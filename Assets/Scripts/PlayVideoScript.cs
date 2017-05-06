using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideoScript : MonoBehaviour
{
    public string SceneName;

	// Use this for initialization
	void Start ()
    {
        Handheld.PlayFullScreenMovie("IntroMovie.mp4");
        SceneManager.LoadSceneAsync(SceneName);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}