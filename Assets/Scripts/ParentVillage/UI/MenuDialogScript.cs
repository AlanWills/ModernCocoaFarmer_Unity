using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuDialogScript : MonoBehaviour
{
    public Sprite AudioPlaying;
    public Sprite AudioMuted;

    private GameObject menuDialogUI;
    private Button audioButton;

	// Use this for initialization
	void Start ()
    {
        AudioListener.pause = false;
        menuDialogUI = GameObject.Find("MenuDialogUI");
        menuDialogUI.SetActive(false);
        audioButton = menuDialogUI.transform.FindChild("Buttons").FindChild("AudioButton").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Show()
    {
        TimeManager.Paused = true;
        menuDialogUI.SetActive(true);
    }

    public void Hide()
    {
        TimeManager.Paused = false;
        menuDialogUI.SetActive(false);
    }

    public void ToggleAudio()
    {
        AudioListener.pause = !AudioListener.pause;
        audioButton.image.sprite = AudioListener.pause ? AudioMuted : AudioPlaying;
    }
}
