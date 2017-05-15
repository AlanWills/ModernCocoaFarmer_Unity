using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraScript : MonoBehaviour {

    bool mouseDownLastFrame = false;
    private Vector3 lastPosition;
    private float maxXTranslation = 0;
    private float maxYTranslation = 0;

	// Use this for initialization
	void Start ()
    {
        Vector3 totalSize = GameObject.Find("VillageBackground").GetComponent<SpriteRenderer>().bounds.extents;
        Vector3 screenDimensionsInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxXTranslation = totalSize.x - screenDimensionsInWorldSpace.x;
        maxYTranslation = totalSize.y - screenDimensionsInWorldSpace.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount == 1 && Input.GetMouseButton(0))
        {
            if (!mouseDownLastFrame)
            {
                mouseDownLastFrame = true;
            }
            else
            {
                Vector3 newPosition = transform.localPosition - (Input.mousePosition - lastPosition) * 0.01f;
                newPosition.x = Mathf.Clamp(newPosition.x, -maxXTranslation, maxXTranslation);
                newPosition.y = Mathf.Clamp(newPosition.y, -maxYTranslation, maxYTranslation);
                transform.localPosition = newPosition;
            }

            lastPosition = Input.mousePosition;
        }
        else
        {
            mouseDownLastFrame = false;
        }
	}
}
