using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float spawnRate = 2f;
    [SerializeField] float maxSpawnRate = 1;
    float timer = 0f;
    // Update is called once per frame
    private void Start()
    {
        EventSystem.custom.enemyKilled += DecreseCooldown;
    }

    void DecreseCooldown()
    {
        if(spawnRate > maxSpawnRate)
        spawnRate -= 0.02f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            transform.position = new Vector2(transform.position.x, Random.Range(-4f, 4f));
            GameObject spawn = Instantiate(EnemyPrefab);
            spawn.transform.position = transform.position;
            timer = 0f;
        }
    }
}
