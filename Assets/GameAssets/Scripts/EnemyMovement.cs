using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Pathfinding;
public class EnemyMovement : MonoBehaviour
{

    bool facingRight;
    bool jump;
    public AIPath aiPath;

    public float speed = 1f;
    [SerializeField] private Animator m_animator;
    // [SerializeField] private bool fireBullets;
    //public Rigidbody2D m_RigidBody2D;
    private static float JUMPRATE = 2f;
    private float nextJump = 0f;
    private float jumpRate;
    /// <summary>
    /// Simple Initializations
    /// </summary>
    void Awake()
    {
        facingRight = true;

        //m_RigidBody2D = this.GetComponent<Rigidbody2D>();
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
        
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            //m_RigidBody2D.velocity = new Vector2(-0.3f * speed, m_RigidBody2D.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector2(1f, 1f);
        }    
        
        // jumping        
        if (jump)
        {
            m_animator.SetBool("Ground", false);
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.3f);            
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
