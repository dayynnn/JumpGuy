using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;
    [SerializeField] private float obstacleTimer = 5f;
    [SerializeField] private float destroyTimer = 10f;

    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > obstacleTimer)
        {
            SpawnObstacle();
            timer = 0;
        }
        timer += Time.deltaTime;

    }

    private void SpawnObstacle()
    {
        Vector2 spawnPoint = (Vector2)transform.position;
        GameObject ground = Instantiate(_obstacle, spawnPoint, Quaternion.identity);
        Destroy(ground, destroyTimer);
    }
}
