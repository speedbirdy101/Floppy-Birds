using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float moveSpeed = 3;

    public LogicScript logic;
    public PipeSpawner pipeSpawner; // Updated type

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        pipeSpawner = GameObject.FindGameObjectWithTag("spawner").GetComponent<PipeSpawner>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
