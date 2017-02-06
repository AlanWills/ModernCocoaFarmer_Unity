using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DropPodScript : MonoBehaviour {

    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponentInParent<Rigidbody2D>();
        rigidBody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKey(KeyCode.Space))
        {
            // Turn on physics for the pod
            rigidBody.isKinematic = false;
            rigidBody.angularVelocity = 100;
        }
	}
}
