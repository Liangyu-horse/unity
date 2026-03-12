using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public GameObject pipePrefab;
    public int pipePoolSize = 5;
    public float spawnRate = 2f;
    public float pipeMin = -0.75f;
    public float pipeMax = -0.25f;
    public float spawnXPosition = 3f;

    private GameObject[] pipes;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private int currentPipe = 0;
    private float timeSinceLastSpawned;

    void Start()
    {
        pipes = new GameObject[pipePoolSize];
        for (int i = 0; i < pipePoolSize; i++)
        {
            pipes[i] = (GameObject)Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawned += Time.deltaTime;

        if (!GameControl.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(pipeMin, pipeMax);
            pipes[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPipe++;
            if (currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }

    }
}
