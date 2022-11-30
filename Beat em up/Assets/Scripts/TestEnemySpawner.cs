using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float cdSize = 1;
    public float cd = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cd >0)
        {
            cd -= Time.deltaTime;
        } else
        {
            Instantiate(enemy, gameObject.transform.position, Quaternion.identity);

            cd = cdSize;
        }
    }
}
