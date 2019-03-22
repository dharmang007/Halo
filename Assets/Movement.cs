using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	bool facingRight;
    bool jump=  false;
    public float speed = 10f;
	private Rigidbody2D m_RigidBody2D;

    public Animator animator;
	// Use this for initialization
	void Start ()
	{
		facingRight = true;
		m_RigidBody2D = this.GetComponent<Rigidbody2D>();
	}
	
    private void Update()
    {
       
    }


	void FixedUpdate () 
	{
		float h = Input.GetAxisRaw("Horizontal"); // gets the value between -1 to 1, where pressing A means -1 and D means 1 
        animator.SetFloat("speed",Math.Abs(h));
		Move(h);
		if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
		{
            jump =true;
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float)0.3);
            jump = false;
		}		
	}

    private void Move(float move)
    {

        m_RigidBody2D.velocity = new Vector2(move*speed, m_RigidBody2D.velocity.y);
        if (move > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

    }

    private void Flip()
    {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
            animator.SetFloat("speed",Math.Abs(transform.localScale.x));
			theScale.x *= -1;
			transform.localScale = theScale;
			
    }
}
