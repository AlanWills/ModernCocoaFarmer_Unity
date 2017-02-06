using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreScript : MonoBehaviour {

    public PickupPodsScript PickupScript;

    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponentInParent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = PickupScript.PodsPickedUp.ToString();
	}
}
