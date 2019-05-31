using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public GameObject bulletPrefab;
    private readonly int bulletsFired = 3;
    private int cnt = 0;
    private GameObject bulletSpawn;
    private readonly float fireRate = .3f;
    private readonly float enemyFireRate = 1f;
    private float nextBullet = 0f;
    public float bulletSpeed = 20f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > nextBullet)
        {
            if(this.tag.Equals("Player", StringComparison.OrdinalIgnoreCase) && Input.GetButton("Fire1"))
            {
                nextBullet = nextBullet + fireRate;
                if (cnt < bulletsFired)
                {
                    Shoot();
                }
                else
                {
                    cnt = 0;
                }
            }
            else if(this.tag.Equals("Enemy",StringComparison.OrdinalIgnoreCase))
            {
                nextBullet = nextBullet + enemyFireRate;
                if (cnt < bulletsFired)
                {
                    Shoot();
                }
                else
                {
                    cnt = 0;
                }
            }

                                        
        }
    }

    void Shoot()
    {
        Quaternion fireDirection;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, 45f); // Fire the bullet in TopRight direction
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, 135f); // Fire the bullet in TopLeft direction
            }
            else
            {
                fireDirection = Quaternion.Euler(0f, 0f, 90f); // Fire upwards
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, -45f); // Fire in BottomRight Corner
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, -135f); // Fire in BottomLeft Corner
            }
            else
            {
                fireDirection = Quaternion.Euler(0f, 0f, -90f); // Fire in Downwards direction
            }
        }
        else
        {
            fireDirection = gunPoint.rotation;
        }

        bulletSpawn = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation); // Create Bullet  
        bulletSpawn.GetComponent<Rigidbody2D>().velocity = gunPoint.transform.right * bulletSpeed;  // Add the velocity to bullet 
        bulletPrefab.GetComponent<BulletTriggers>().firedBy = gameObject.tag; // tag name which will be used to check which bullet was fired by whom                
        cnt++;
        Destroy(bulletSpawn, 2f); // Destroy Bullet after 2 seconds
    }
}
