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
    public Rigidbody2D m_RigidBody2D;
    float timer=5f;
    void Awake()
    {
        facingRight = true;
        m_RigidBody2D = this.GetComponent<Rigidbody2D>();
        m_animator =this.GetComponent<Animator>();
        m_animator.SetFloat("Speed",speed);
        m_animator.SetBool("Ground",true);
        jump = false;
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (!jump)
        {
            m_animator.SetBool("Ground", true);
        }

        m_animator.SetFloat("Speed", 1);
        m_RigidBody2D.velocity = new Vector2(-0.5f * speed, m_RigidBody2D.velocity.y);
        
        // jumping        
        if (jump)
        {
            m_animator.SetBool("Ground", false);
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.3f);
        }
    }
}
