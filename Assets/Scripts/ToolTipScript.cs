using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class ToolTipScript : MonoBehaviour {

    public GameObject ToolTip;

    private const float HoverTime = 0.25f;
    private float currentTime = 0;
    private Collider2D _collider;

	// Use this for initialization
	void Start ()
    {
        _collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (_collider.bounds.Contains(Input.mousePosition))
        {
            currentTime += Time.deltaTime;
            if (currentTime >= HoverTime)
            {
                ToolTip.SetActive(true);
            }
        }
        else
        {
            currentTime = 0;
            ToolTip.SetActive(false);
        }
	}
}
