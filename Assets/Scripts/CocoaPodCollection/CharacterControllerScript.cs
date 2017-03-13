using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControllerScript : MonoBehaviour {

    public float Speed = 3;
    public float JumpHeight = 6;
    public float TimeBetweenCuts = 0.5f;

    public int PodsPickedUp { get; private set; }

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody2D;

    private float canCutTimer = 0;
    private bool canJump = true;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        PodsPickedUp = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Quaternion.identity;
        canCutTimer += Time.deltaTime;

        if (canJump)
        {
            // We should only be able to walk if we can jump - i.e. we haven't jumped already
            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal < 0)
            {
                transform.localPosition += new Vector3(-Speed * Time.deltaTime, 0, 0);
                spriteRenderer.flipX = true;
                animator.SetBool("Walk", true);
            }
            else if (horizontal > 0)
            {
                transform.localPosition += new Vector3(Speed * Time.deltaTime, 0, 0);
                spriteRenderer.flipX = false;
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            if (Input.GetAxis("Jump") > 0)
            {
                float sidewaysSpeed = horizontal == 0 ? 0 : Mathf.Sign(horizontal) * Speed;
                rigidBody2D.velocity = new Vector2(sidewaysSpeed, JumpHeight);
                animator.SetBool("Walk", false);
                canJump = false;
            }
        }

        if (canCutTimer >= TimeBetweenCuts && Input.GetAxis("Fire1") > 0)
        {
            animator.SetTrigger("Chop");
            canCutTimer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            // Have to make sure that we are in the middle of a chop animation to collect a pod
            if (canCutTimer < 0.25f)
            {
                Destroy(collision.gameObject);
                PodsPickedUp++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
