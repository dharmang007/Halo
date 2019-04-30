using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public GameObject bulletPrefab;
    int bulletsFired = 0;
    const int AmmoCap = 1;
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
        Instantiate(bulletPrefab,gunPoint.position,gunPoint.rotation);
        if(bulletsFired <= AmmoCap)
        {
            bulletsFired++;
        }      
    }

}
