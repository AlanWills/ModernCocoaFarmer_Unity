using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMovementScript : MonoBehaviour {

    public float Speed = 3;

    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-Speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(Speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
        }

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.localPosition += new Vector3(0, Time.deltaTime, 0);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.localPosition += new Vector3(0, -Time.deltaTime, 0);
        //}
    }
}
