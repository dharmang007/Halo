using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageEnemies : MonoBehaviour
{
    [SerializeField] public GameObject redElitePrefab;
    [SerializeField] public GameObject playerPrefab;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());        
    }

    IEnumerator EnemySpawner()
    {
        while(true)
        {
            Instantiate(redElitePrefab,transform.position,transform.rotation * Quaternion.Euler(0f,180f,0f));            
            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
               
    }
}
