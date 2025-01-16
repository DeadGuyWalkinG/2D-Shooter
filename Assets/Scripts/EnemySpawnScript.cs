using System.Runtime.CompilerServices;
using static UnityEngine.Random;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private float minSpawnRate=3f;
    [SerializeField] private float maxSpawnRate=6f;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnPoint=15f;
    private float nextSpawn;
    private float spawn;
    private int flag;
    void Start()
    {
        flag = 0;
        nextSpawn = minSpawnRate;
    }

    void Update()       
    {
        if (Time.time > nextSpawn)
        {
            if (flag == 0)
            {
                spawn = calculateSpawn();
                flag = 1;
            }
            if (Time.time >= (nextSpawn + spawn))
            {
                Instantiate(enemy, new Vector2(spawnPos(), 3), Quaternion.identity);
                nextSpawn = Time.time + minSpawnRate;
                Debug.Log("Enemy spawned randomly\nnextSpawn: " + nextSpawn + "\nspawn: " + spawn + "\nActal Spawn Time: " + (nextSpawn + spawn));
                flag = 0;
            }
        }
        else if (Time.time >= (nextSpawn + maxSpawnRate))
        {
            Instantiate(enemy, new Vector2(spawnPos(), 3), Quaternion.identity);
            nextSpawn = Time.time + minSpawnRate;
            Debug.Log("Enemy spawned at end of spawn rate");
            flag = 0;
        }
    }

    float spawnPos()
    {
        int i;
        i = Random.Range(1, 3);
        if (i == 1)
           return spawnPoint;
        else
            return -spawnPoint;
    }

    float calculateSpawn()
    {
        float d;
        d = maxSpawnRate - minSpawnRate;
        return Random.Range(0, d + 1);
    }

}
