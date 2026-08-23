using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] animals;
    public int spawnRange = 15;
    public float spawnInterval = 1f;
    private int health = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(health + " Health Remaining");
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // Spawn a random animal at a random x position
        int index = Random.Range(0, animals.Length);
        int xPosition = Random.Range(-spawnRange, spawnRange);
        int zPosition = 20;

        GameObject newAnimal = Instantiate(animals[index], new Vector3(xPosition, 0, zPosition), animals[index].transform.rotation);
        DestroyOutOfBounds animal = newAnimal.GetComponent<DestroyOutOfBounds>();
        animal.Initialize(this);
    }

    public void ReduceHealth()
    {
        health--;
        Debug.Log(health + " Health Remaining");
        if (health < 1)
        {
            StopSpawning();
            Debug.Log("Game Over!");
        }
    }

    public void StopSpawning()
    {
        CancelInvoke("Spawn");
    }
}
