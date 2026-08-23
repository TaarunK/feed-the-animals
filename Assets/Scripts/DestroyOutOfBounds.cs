using Unity.Hierarchy;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBound = 30f;
    private float lowerBound = -10f;
    private SpawnerScript spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Initialize(SpawnerScript spawner) 
    {
        this.spawner = spawner;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > upperBound)
        {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            spawner.ReduceHealth();
            
        }
    }
}
