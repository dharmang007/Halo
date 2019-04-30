using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class EnemyMovement : MonoBehaviour
{

    bool facingRight; 
    bool jump;
    public float speed = 2f;
    [SerializeField] private Animator m_animator;
    public Rigidbody2D m_RigidBody2D;

    void Awake()
    {
        facingRight = true;
        m_RigidBody2D = this.GetComponent<Rigidbody2D>();
        m_animator =this.GetComponent<Animator>();
        m_animator.SetFloat("Speed",speed);
        m_animator.SetBool("Ground",true);
    }

    // Update is called once per frame
    void Update()
    {
        
        m_RigidBody2D.velocity = new Vector2(-0.5f*speed,m_RigidBody2D.velocity.y);       
    }
}
