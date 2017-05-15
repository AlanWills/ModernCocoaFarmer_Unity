using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCameraScript : MonoBehaviour {

    bool mouseDownLastFrame = false;
    private Vector3 lastPosition;
    private float maxXTranslation = 0;
    private float maxYTranslation = 0;
    private float maxCameraSize;

	// Use this for initialization
	void Start ()
    {
        Vector3 totalSize = GameObject.Find("VillageBackground").GetComponent<SpriteRenderer>().bounds.extents;
        Vector3 screenDimensionsInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxXTranslation = totalSize.x - screenDimensionsInWorldSpace.x;
        maxYTranslation = totalSize.y - screenDimensionsInWorldSpace.y;
        maxCameraSize = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float ratio = maxCameraSize / Camera.main.orthographicSize;

        if ((Input.touchCount < 2) && Input.GetMouseButton(0))
        {
            if (!mouseDownLastFrame)
            {
                mouseDownLastFrame = true;
            }
            else
            {
                transform.localPosition -= (Input.mousePosition - lastPosition) * 0.01f / ratio;
            }

            lastPosition = Input.mousePosition;
        }
        else
        {
            mouseDownLastFrame = false;
        }

        float maxXTranslationScaledWithCamera = maxXTranslation * ratio;
        float maxYTranslationScaledWithCamera = maxYTranslation * ratio;

        Vector3 newPosition = transform.localPosition;
        newPosition.x = Mathf.Clamp(newPosition.x, -maxXTranslationScaledWithCamera, maxXTranslationScaledWithCamera);
        newPosition.y = Mathf.Clamp(newPosition.y, -maxYTranslationScaledWithCamera, maxYTranslationScaledWithCamera);
        transform.localPosition = newPosition;
    }
}
