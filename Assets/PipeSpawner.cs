using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe; // Assign the pipe prefab in the Inspector
    public float baseSpawnInterval = 3f; // Base time interval between spawns
    private float spawnInterval; // Dynamic spawn interval
    private float timer; // Timer to track spawn intervals

    public LogicScript logic; // Reference to LogicScript to get the score
    public float minSpawnInterval = 1f; // Minimum spawn interval limit

    void Start()
    {
        if (pipe == null)
        {
            print("Pipe prefab is not assigned!");
            return;
        }

        // Get the LogicScript reference
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnInterval = baseSpawnInterval;
        SpawnPipe();
    }

    void Update()
    {
        // Dynamically adjust spawn interval based on player score
        spawnInterval = Mathf.Max(minSpawnInterval, baseSpawnInterval / (1 + (logic.playerScore / 10))); // Reduce interval as score increases

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f; // Reset the timer
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - 4;
        float heighestPoint = transform.position.y + 4;

        if (pipe != null)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation);
        }
    }
}
