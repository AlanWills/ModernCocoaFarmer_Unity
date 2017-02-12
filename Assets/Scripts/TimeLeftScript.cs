using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(TransitionToSceneScript))]
public class TimeLeftScript : MonoBehaviour {

    public int LevelTime = 120;

    private GameObject payslip;
    private TransitionToSceneScript transition;
    private Text timeLeftText;
    private float timer = 0;
    private bool finished = false;

	// Use this for initialization
	void Start ()
    {
        transition = GetComponentInParent<TransitionToSceneScript>();
        timeLeftText = GetComponentInParent<Text>();
        timeLeftText.text = LevelTime.ToString();

        payslip = GameObject.Find("Payslip");
        payslip.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        timeLeftText.text = Mathf.RoundToInt(LevelTime - timer).ToString();

        if (!finished && timer > LevelTime)
        {
            CharacterControllerScript controller = GameObject.Find("Worker").GetComponent<CharacterControllerScript>();
            controller.gameObject.SetActive(false);

            payslip.SetActive(true);
            payslip.GetComponentInChildren<Text>().text = controller.PodsPickedUp.ToString();
            transition.Countdown = 4;

            finished = true;
        }
	}
}
