using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeLeftScript : MonoBehaviour {

    public int LevelTime = 120;

    private Text timeLeftText;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        timeLeftText = GetComponentInParent<Text>();
        timeLeftText.text = LevelTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timeLeftText.text = ((int)(LevelTime - timer)).ToString();

        if (timer > LevelTime)
        {
            // Stop
        }
	}
}
