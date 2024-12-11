using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] private float spawnTimer = 10f;

    private float timer;

    private void Start()
    {
        
        //SpawnCoin();        
        InvokeRepeating("SpawnCoin", 5f, 5f);
    }
    
    private void Update()
    {
        
        if (timer > spawnTimer)
        {
            SpawnCoin();
            timer = 0;

        }
        timer += Time.deltaTime;
    }
    private void SpawnCoin()
    {
        Vector2 spawnPoint = (Vector2)transform.position;
        GameObject coins = Instantiate(coin, spawnPoint, Quaternion.identity);

    }
}
