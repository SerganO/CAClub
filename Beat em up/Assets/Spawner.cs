using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner property")]
    public string ID;

    public void Spawn(GameObject enemyForSpawn)
    {
        Spawn(enemyForSpawn, gameObject.transform.position);
    }

    public void Spawn(GameObject enemyForSpawn, Vector3 position)
    {
        Instantiate(enemyForSpawn.gameObject, position, Quaternion.identity);
    }

    public void Spawn(Enemy enemyForSpawn)
    {
        Spawn(enemyForSpawn, gameObject.transform.position);
    }

    public void Spawn(Enemy enemyForSpawn, Vector3 position)
    {
        Instantiate(enemyForSpawn.gameObject, position, Quaternion.identity);
    }
}