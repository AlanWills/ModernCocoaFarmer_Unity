using UnityEngine;

public class PinchZoomScript : MonoBehaviour
{
    private const float orthoZoomSpeed = 0.01f;        // The rate of change of the orthographic size in orthographic mode.
    private float maxZoom;
    private Camera attachedCamera;

    void Start()
    {
        attachedCamera = GetComponent<Camera>();
        maxZoom = attachedCamera.orthographicSize;
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // ... change the orthographic size based on the change in distance between the touches.
            attachedCamera.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

            // Make sure the orthographic size never drops below zero.
            attachedCamera.orthographicSize = Mathf.Clamp(attachedCamera.orthographicSize, 0.1f, maxZoom);
        }
    }
}