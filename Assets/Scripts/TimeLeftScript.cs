using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(TransitionToSceneScript))]
public class TimeLeftScript : MonoBehaviour {

    public int LevelTime = 120;

    private TransitionToSceneScript transition;
    private Text timeLeftText;
    private float timer = 0;

	// Use this for initialization
	void Start () {
        transition = GetComponentInParent<TransitionToSceneScript>();
        timeLeftText = GetComponentInParent<Text>();
        timeLeftText.text = LevelTime.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timeLeftText.text = Mathf.RoundToInt(LevelTime - timer).ToString();

        if (timer > LevelTime)
        {
            transition.ForceTransition();
        }
	}
}
