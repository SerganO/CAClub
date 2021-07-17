using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoaderObject : MonoBehaviour
{

    public delegate void GameObjectFunc(GameObject gameObject);

    public static GameObject GetEnemyForId(string id)
    {
        return Resources.Load("Enemy/" + id) as GameObject;
    }

    public static void GetEnemyWithCompletion(string id, GameObjectFunc completion)
    {
        completion(GetEnemyForId(id));
    }

    public void GetEnemyForIDs(List<string> ids, VoidFunc completion)
    {
        StartCoroutine(GetEnemyForIDsCoroutine(ids, completion));
    }

    public List<GameObject> enemies = new List<GameObject>();

    IEnumerator GetEnemyForIDsCoroutine(List<string> ids, VoidFunc completion)
    {
        enemies = new List<GameObject>();
        foreach (var id in ids)
        {
            Debug.Log(id);
            GetEnemyWithCompletion(id, (x) => enemies.Add(x));
            yield return new WaitForSeconds(0.05f);
        }
        completion();

    }


}
