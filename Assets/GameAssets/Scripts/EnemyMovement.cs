using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class EnemyMovement : MonoBehaviour
{

    bool facingRight;
    bool jump;
    public float speed = 1f;
    [SerializeField] private Animator m_animator;
    // [SerializeField] private bool fireBullets;
    public Rigidbody2D m_RigidBody2D;
    private static float JUMPRATE = 2f;
    private float nextJump = 0f;
    private float jumpRate;
    /// <summary>
    /// Simple Initializations
    /// </summary>
    void Awake()
    {
        facingRight = true;
        m_RigidBody2D = this.GetComponent<Rigidbody2D>();
        m_animator =this.GetComponent<Animator>();
        m_animator.SetFloat("Speed",speed);
        m_animator.SetBool("Ground",true);
        jump = false;
        nextJump = Time.time + nextJump;
        // Time.time is time in seconds since the start of the game
    }

    
    /// <summary>
    /// This update function is used to make enemy character jump after certain time rate
    /// </summary>
    private void Update()
    {

        /* **** Crash Prone Solution ******* 
        if (Time.time > nextJump && jump == false)
        {
            nextJump = Time.time + jumpRate; // this sets limit for next jump 
            jump = true;
        }*/

        jumpRate -= Time.deltaTime;
        if( jumpRate <= 0 && !jump)
        {
            jump = true;
            jumpRate = JUMPRATE; // reset the value
        }

    }

    /// <summary>
    /// Handles the basic motion of the enemy. It uses the jump flag to check whether the enemy should jump or not
    /// </summary>
    void FixedUpdate()
    {
        if (!jump)
        {
            m_animator.SetBool("Ground", true);
        }

        m_animator.SetFloat("Speed", 1);
        m_RigidBody2D.velocity = new Vector2(-0.3f * speed, m_RigidBody2D.velocity.y);
        
        // jumping        
        if (jump)
        {
            m_animator.SetBool("Ground", false);
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.3f);            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy")
        {
            jump = false;
        }
    }
}
