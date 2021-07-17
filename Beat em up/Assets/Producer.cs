using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Producer : MonoBehaviour
{
    public LevelSceneHandler handler;
    public event VoidFunc OnSuccess;

    Dictionary<Enemy.Type, List<GameObject>> enemies = new Dictionary<Enemy.Type, List<GameObject>>() {
        { Enemy.Type.small, new List<GameObject>() },
        { Enemy.Type.medium, new List<GameObject>() },
        { Enemy.Type.big, new List<GameObject>() },
        { Enemy.Type.range, new List<GameObject>() },
        { Enemy.Type.boss, new List<GameObject>() }
    };

    LevelEnemiesQueue queue;

    public List<Spawner> spawners;

    public float cdSize = 1;
    public float cd = 1;
    // Create AssetBundle variable to store the data of the bundles
    int n = 10;
    int nc = 0;

    bool isFirstUpdate = true;

    public bool enemyReady = false;

    public EnemyLoaderObject loader;

    void Start()
    {
        var level = handler.GetLevel();
        Debug.Log(level);
        GetEnemyForLevel(level);
    }

    private void GetEnemyForLevel(string level)
    {
        switch(level)
        {
            default:
                loader.GetEnemyForIDs(InformationMaster.enemies[level], () => {

                    foreach (var enemy in loader.enemies)
                    {
                        Debug.Log(enemy.GetComponent<Enemy>().type);
                        enemies[enemy.GetComponent<Enemy>().type].Add(enemy);

                        
                    }
                    GetLevelEnemyQueue(level);
                    enemyReady = true;
                });
                break;
        }
    }

    private void GetLevelEnemyQueue(string level)
    {
        queue = InformationMaster.levelEnemies[level];
    }

    int CurrentEnemyCount
    {
        get
        {
            return GameObject.FindGameObjectsWithTag("Enemy").Length;
        }
    }

    bool needSpawn = true;
    public void Update()
    {


        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else
        {
            if (!enemyReady || !needSpawn) return;

            Debug.Log(queue);
            SpawnQueueWithCompletion(queue, 0, () =>
            {
                OnSuccess();
            });
            needSpawn = false;


        }
    }



    IEnumerator SuccessCompletion(VoidFunc completion)
    {
        while (CurrentEnemyCount > 0)
        {
            yield return new WaitForSeconds(1f);
        }
        completion();
    }

    void SpawnQueueWithCompletion(LevelEnemiesQueue queue, int cursor, VoidFunc completion)
    {
        //Debug.Log("Q " + cursor);
        SpawnWaveWithCompletion(queue.waves[cursor], 0, () =>
        {
            if ((cursor + 1) >= queue.waves.Count)
            {
                StartCoroutine(SuccessCompletion(completion));
            }
            else
            {
                SpawnQueueWithCompletion(queue, cursor + 1, completion);
            }
        });
    }
    


    void SpawnWaveWithCompletion(EnemiesWave wave, int cursor, VoidFunc completion)
    {
        //Debug.Log("W " + cursor);
        SpawnGroupWithCompletion(wave.groups[cursor], 0, () =>
        {
            if ((cursor + 1) >= wave.groups.Count)
            {
                completion();
            }
            else
            {
                SpawnWaveWithCompletion(wave, cursor+1, completion);
            }
        });
    }

    IEnumerator GroupSpawnCoroutine(float time, VoidFunc completion)
    {
        var localTime = time;
        while (CurrentEnemyCount > 0  && localTime > 0)
        {
            //Debug.Log("enemy: " + currentEnemyCount);
            //Debug.Log("time: " + localTime);
            yield return new WaitForSeconds(1f);
            localTime -= 1;
        }
        completion();
    }

    void SpawnGroupWithCompletion(EnemiesGroup group, int cursor, VoidFunc completion)
    {
        //Debug.Log("G " + cursor);
        StartCoroutine(SpawnPairWithCompletion(group.pairs[cursor], () =>
        {
            if((cursor + 1)>= group.pairs.Count)
            {
                StartCoroutine(GroupSpawnCoroutine(group.time, completion));
            } else
            {
                SpawnGroupWithCompletion(group, cursor+1, completion);
            }
        }));
    }

    IEnumerator SpawnPairWithCompletion(EnemiesPair pair, VoidFunc completion)
    {
        for(int i=0;i<pair.count;i++)
        {
            //Debug.Log("P " + i);
            var spawner = spawners[Random.Range(0, spawners.Count)];
            var ego = RandomEnemyForType(pair.type);
            spawner.Spawn(ego);
            yield return new WaitForSeconds(1f);
        }  
        completion();
    }

    GameObject RandomEnemyForType(Enemy.Type type)
    {
        return enemies[type][Random.Range(0, enemies[type].Count)];
    }


}






