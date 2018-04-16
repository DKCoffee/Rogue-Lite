using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Rigidbody2D body;
    private float speed = 5;
    private float force = 10;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        spriteRenderer.flipX = horizontalInput > 0;
        Vector2 forceDirection = new Vector2(horizontalInput, 0);
        forceDirection *= force;
        body.AddForce(forceDirection);
        if (Input.GetAxis("Jump") > 0 && touchFloor)
        {
            soundsJump.PlaySound();
            rigid.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }
}
