using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraScript : MonoBehaviour
{
    public Transform Transform;
    public float maxX = float.MaxValue;
    public float minX = float.MinValue;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.localPosition = new Vector3(Mathf.Clamp(Transform.position.x, minX, maxX), transform.localPosition.y, transform.localPosition.z);
	}
}
