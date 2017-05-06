using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Handheld.PlayFullScreenMovie("IntroMovie.mp4");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
