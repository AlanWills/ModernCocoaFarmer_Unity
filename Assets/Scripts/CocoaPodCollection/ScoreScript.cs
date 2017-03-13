using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreScript : MonoBehaviour {

    public CharacterControllerScript CharacterController;
    public int Target = 50;

    private Text scoreText;
    private Text moneyText;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Collected:  " + CharacterController.PodsPickedUp.ToString() + " / " + Target.ToString();
        moneyText.text = "Francs:  " + CalculateMoney().ToString();
    }

    private int CalculateMoney()
    {
        return CharacterController.PodsPickedUp * 2;
    }
}
