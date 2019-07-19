using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	bool facingRight;
    bool jump;
    [SerializeField] private readonly float jumpforce = 0.3f;
    [SerializeField] private readonly float speed = 10f;    
    [SerializeField] private Animator m_animator;
	private Rigidbody2D m_RigidBody2D;
    
    /// <summary>
    /// Simple Initializations 
    /// </summary>
	void Awake()
	{
		facingRight = true;
		m_RigidBody2D = this.GetComponent<Rigidbody2D>();
        m_animator = this.GetComponent<Animator>();
	}

    /// <summary>
    /// Set the jump flag when "Jump" is pressed
    /// This flag will be used in Fixed update to move the player
    /// </summary>
    private void Update() 
    { 
         
        if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}        
    }
 
    /// <summary>
    /// This will call the Move method which handles the motion of player
    /// </summary>
	void FixedUpdate () 
	{ 
		float h = Input.GetAxisRaw("Horizontal"); // gets the value between -1 to 1, where pressing A means -1 and D means 1 
		Move(h);
	}

    /// <summary>
    /// This method adds appropriate movements to the player like fliping the direction, setting the animation, jumping and adding the velocity
    /// </summary>
    /// <param name="move">This value corresponds to the input axis which ranges from -1 to 1. Where pressing A means -1 and D means 1</param>
    private void Move(float move)
    {

        if(!jump) 
        {
            // the player is not jumping and he is on the ground (some platform where he can stand)
            m_animator.SetBool("Ground",true); 
        }

        m_animator.SetFloat("Speed",Mathf.Abs(move));        
        m_RigidBody2D.velocity = new Vector2(move*speed, m_RigidBody2D.velocity.y);
       
        if ((move > 0 && !facingRight) || move < 0 && facingRight)
        {
            // ... flip the player.
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }

        // jumping action
        if(jump)
        {
            m_animator.SetBool("Ground",false);
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // The player should drop down from platorm. E.g Contra             
            }
            else
            {
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + jumpforce);
            }            
        }      	 
    }

    /// <summary>
    ///  Whenever Player jumps and lands on enemy the jumping action should not be stopped.
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy")
        {
            jump = false;
        }
    }
}