using UnityEngine;

public class EnemySpawner : LivingObject {


    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public GameObject[] enemies;

    // TODO: use width an height in enemy spawning
    //float width = 10.0f;
    //float height = 5.0f;



    public void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Update () {

    }

    void Spawn () {
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity);
    }
}
