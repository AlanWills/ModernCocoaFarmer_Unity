using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BarScript : MonoBehaviour
{
    public float Min;
    public float Max;

    private float _value = 0;
    public float Value
    {
        get { return _value; }
        set
        {
            _value = value;
            transform.localScale = new Vector3((_value - Min) / (Max - Min), 1, 1);
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
