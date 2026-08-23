using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float fieldSize = 15f;
    public float speed = 10f;
    public GameObject projectilePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player boundaries
        if (transform.position.x < -fieldSize)
        {
            transform.position = new Vector3(-fieldSize, transform.position.y, transform.position.z);
        }

        if (transform.position.x > fieldSize)
        {
            transform.position = new Vector3(fieldSize, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
