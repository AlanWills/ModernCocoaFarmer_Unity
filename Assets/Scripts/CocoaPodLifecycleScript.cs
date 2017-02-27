using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class CocoaPodLifecycleScript : MonoBehaviour {

    public float LifeTime = 2;

    private float currentTimer = 0;
    private Rigidbody2D podRigidBody;
    private SpriteRenderer spriteRenderer;
    private bool dying = false;

	// Use this for initialization
	void Start ()
    {
        podRigidBody = GetComponentInParent<Rigidbody2D>();
        podRigidBody.isKinematic = true;

        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTimer += Time.deltaTime;

        if (!dying)
        {
            if (currentTimer > LifeTime)
            {
                podRigidBody.isKinematic = false;
            }
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - 0.01f);

            if (spriteRenderer.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            dying = true;
            podRigidBody.velocity = Vector2.zero;
            podRigidBody.isKinematic = true;
        }
    }
}
