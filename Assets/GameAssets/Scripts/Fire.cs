using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public GameObject bulletPrefab;
    private int bulletsFired = 3,cnt=0;
    private GameObject bulletSpawn;
    private float fireRate = .3f, nextBullet=0f;

    void Start()
    {
        nextBullet = nextBullet + Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextBullet)
        {
            nextBullet = nextBullet + fireRate;
            if(cnt < bulletsFired)
            {
                Shoot();
            }
            else
            {
                cnt = 0;
            }
                
        }
    }

    void Shoot()
    {
        Quaternion fireDirection;
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            if(Input.GetAxisRaw("Horizontal")>0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, 45f);
            }
            else if(Input.GetAxisRaw("Horizontal")<0)
            {
                fireDirection = Quaternion.Euler(0f,0f,135f);
            }
            else
            {
                fireDirection = Quaternion.Euler(0f,0f,90f);
            }
        }
        else if(Input.GetAxisRaw("Vertical") < 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, -45f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                fireDirection = Quaternion.Euler(0f, 0f, -135f);
            }
            else
            {
                fireDirection = Quaternion.Euler(0f, 0f, -90f);
            }
        }

        else
        {
            fireDirection = gunPoint.rotation;
        }
        bulletSpawn = Instantiate(bulletPrefab, gunPoint.position, fireDirection); // Create Bullet
        cnt++;
        Destroy(bulletSpawn, 2f); // Destroy Bullet after 2 seconds
    }
}
