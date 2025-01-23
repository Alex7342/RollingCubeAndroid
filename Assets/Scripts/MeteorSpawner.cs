using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Avoid Player")]
    public bool avoidPlayer = false;
    public Transform player;
    public float distanceFromPlayer = 2.5f;

    [Header("Spawner Settings")]
    public GameObject meteorPrefab;
    public float spawnRate = 0.33f;
    public float maxSpawnRate = 5f;
    public float spawnRateIncrease = 0.015f;
    private float timeUntilNextSpawn;
    public float leftBound = -15f;
    public float rightBound = 15f;
    public float spawnHeight = 25f;

    private void Start()
    {
        timeUntilNextSpawn = 1f / spawnRate;
    }

    private void Update()
    {
        if (timeUntilNextSpawn <= 0f)
        {
            SpawnMeteor();
            timeUntilNextSpawn = 1f / spawnRate;
            spawnRate += 0.015f;
            spawnRate = Mathf.Clamp(spawnRate, 0f, maxSpawnRate);
        }

        timeUntilNextSpawn -= Time.deltaTime;
    }

    private void SpawnMeteor()
    {
        Instantiate(meteorPrefab, GetSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        float spawnPosition = Random.Range(leftBound, rightBound);

        if (avoidPlayer == true)
        {
            if (Mathf.Abs(spawnPosition - player.position.x) < distanceFromPlayer)
            {
                if (spawnPosition - distanceFromPlayer >= leftBound)
                {
                    spawnPosition -= distanceFromPlayer;
                }
                else
                {
                    spawnPosition += distanceFromPlayer;
                }
            }
        }

        return new Vector3(spawnPosition, spawnHeight, 0f);
    }
}
