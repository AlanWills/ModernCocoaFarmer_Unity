using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideoScript : MonoBehaviour
{
    public string SceneName;

	// Use this for initialization
	void Awake ()
    {
        Handheld.PlayFullScreenMovie("IntroMovie.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
        SceneManager.LoadSceneAsync(SceneName);
    }
}