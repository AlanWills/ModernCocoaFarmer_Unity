using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterControllerScript : MonoBehaviour {

    public float Speed = 3;

    public int PodsPickedUp { get; private set; }

    private SpriteRenderer spriteRenderer;
    private Animator animator;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        animator = GetComponentInParent<Animator>();

        PodsPickedUp = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.localPosition += new Vector3(-Speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = false;
            animator.SetBool("Walk", true);
        }
        else if (horizontal > 0)
        {
            transform.localPosition += new Vector3(Speed * Time.deltaTime, 0, 0);
            spriteRenderer.flipX = true;
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float pickup = Input.GetAxis("Fire1");
        if (pickup > 0 && collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);
            PodsPickedUp++;
        }
    }
}
