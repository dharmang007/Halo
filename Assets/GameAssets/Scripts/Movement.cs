using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	bool facingRight;
    bool jump;
    public float speed = 10f;    
    [SerializeField] private Animator m_animator;
	private Rigidbody2D m_RigidBody2D;
    
	void Awake()
	{
		facingRight = true;
		m_RigidBody2D = this.GetComponent<Rigidbody2D>();
        m_animator = this.GetComponent<Animator>();
	}
	
    private void Update() 
    {
        if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}        
    }
 
	void FixedUpdate () 
	{ 
		float h = Input.GetAxisRaw("Horizontal"); // gets the value between -1 to 1, where pressing A means -1 and D means 1 
		Move(h);
	}

    private void Move(float move)
    {

        if(!jump)
        {
            m_animator.SetBool("Ground",true);
        }

        m_animator.SetFloat("Speed",Mathf.Abs(move));        
        m_RigidBody2D.velocity = new Vector2(move*speed, m_RigidBody2D.velocity.y);
        if ((move > 0 && !facingRight) || move < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // jumping        
        if(jump)
        {
            m_animator.SetBool("Ground",false);
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y + 0.3f);
        } 
        	 
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy")
        {
            jump = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);			
    }
}