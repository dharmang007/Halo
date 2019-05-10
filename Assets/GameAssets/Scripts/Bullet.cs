using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 20f;
    public GameObject bulletFiredBy;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }
   
}
