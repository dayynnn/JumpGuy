using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    [SerializeField] GameObject _ground;
    [SerializeField] private float groundTimer = 5f;
    [SerializeField] private float destroyTimer = 10f;

    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnGround();    
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > groundTimer)
        {
            SpawnGround();
            timer = 0;
        }
        timer += Time.deltaTime;
       
    }

    private void SpawnGround()
    {
        Vector2 spawnPoint = (Vector2)transform.position;
        GameObject ground = Instantiate(_ground, spawnPoint, Quaternion.identity);
        Destroy(ground, destroyTimer);
    }
}
