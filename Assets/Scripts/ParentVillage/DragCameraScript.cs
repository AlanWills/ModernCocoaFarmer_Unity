using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraScript : MonoBehaviour {

    bool mouseDownLastFrame = false;
    private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            if (!mouseDownLastFrame)
            {
                mouseDownLastFrame = true;
            }
            else
            {
                transform.localPosition -= (Input.mousePosition - lastPosition) * 0.01f;
            }

            lastPosition = Input.mousePosition;
        }
        else
        {
            mouseDownLastFrame = false;
        }
	}
}
