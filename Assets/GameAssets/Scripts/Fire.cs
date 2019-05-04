using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public GameObject bulletPrefab;
    private int bulletsFired = 3;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        Instantiate(bulletPrefab,gunPoint.position, gunPoint.rotation);
        bulletsFired++;
    }
}
