using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BarScript : MonoBehaviour
{
    public float Min;
    public float Max;
    public float StartingValue;

    private float _value;
    public float Value
    {
        get { return _value; }
        set
        {
            _value = value;
            transform.localScale = new Vector3((_value - Min) / (Max - Min), 1, 1);
        }
    }

    private Image image;

	// Use this for initialization
	void Start ()
    {
        Value = StartingValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
