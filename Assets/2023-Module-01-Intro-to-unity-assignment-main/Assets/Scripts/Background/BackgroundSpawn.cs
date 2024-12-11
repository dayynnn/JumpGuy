using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    [SerializeField] GameObject bg;
    [SerializeField] private float bgTimer = 15f;
    [SerializeField] private float destroyTimer = 10f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bgTimer)
        {
            SpawnBackground();
            timer = 0;
        }
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    private void SpawnBackground()
    {
        Vector2 spawnPoint = (Vector2)transform.position;
        GameObject ground = Instantiate(bg, spawnPoint, Quaternion.identity);
        Destroy(ground, destroyTimer);
    }
}
