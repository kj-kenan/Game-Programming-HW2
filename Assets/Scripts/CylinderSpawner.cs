using UnityEngine;
using System.Collections;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject cylinderPrefab;
    public float spawnInterval = 6f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(spawnInterval); 

        while (true)
        {
            Instantiate(cylinderPrefab, initialPosition, initialRotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
