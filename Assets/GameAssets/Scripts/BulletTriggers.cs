using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggers : MonoBehaviour
{

    public string firedBy = string.Empty;
    // Start is called before the first frame update 
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (firedBy.Equals("Player") &&  target.gameObject.CompareTag("Enemy"))
        {
           
            Destroy(target.gameObject);
            Destroy(gameObject);
        }      
    }
}
