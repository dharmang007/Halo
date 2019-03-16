using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	bool facingRight;
	private Rigidbody2D m_RigidBody2D;
	// Use this for initialization
	void Start ()
	{
		facingRight = true;
		m_RigidBody2D = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		Move(h);
		/*
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{		
			
			if(!facingRight)
			{
				Flip();				
			}
			else
			{
				this.transform.position = new Vector2(this.transform.position.x+ (float).1,this.transform.position.y);
			}				
		}
		else if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
		{
			if(facingRight)
			{
				Flip();
			}
			else 
			{
				this.transform.position = new Vector2(this.transform.position.x-(float).1,this.transform.position.y);	
			}
			facingRight = false;

		}
		else if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float).1);
		}*/
		if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
		{
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float).1);
		}		
	}

    private void Move(float move)
    {
		
       m_RigidBody2D.velocity = new Vector2(move*(2), m_RigidBody2D.velocity.y);
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
		theScale.x *= -1;
		transform.localScale = theScale;
			
    }
}
