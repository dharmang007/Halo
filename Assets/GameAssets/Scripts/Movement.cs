using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	bool facingRight;
    bool jump;
    public float speed = 10f;
    //public float m_JumpForce = 400f;
  
    
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

        if(jump == false)
        {
            m_animator.SetBool("Ground",true);
        }

        m_animator.SetFloat("Speed",Mathf.Abs(move));
        
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
        // jumping
        
        if(jump)
        {
            m_animator.SetBool("Ground",false);
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float)0.3);
        } 
        

       /*
       if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)&& !jump)
		{
            
            jump = true;
            m_animator.SetBool("Ground",false);
			this.transform.position = new Vector2(this.transform.position.x,this.transform.position.y+(float)0.3);     
            //m_RigidBody2D.AddForce(new Vector2(0f,1f),ForceMode2D.Force);
        } 
       */
        	 
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
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
			
    }
}