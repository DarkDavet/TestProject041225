using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IShooting
{
    [Header("Spawn Settings")]
    public GameObject spawnObjectPrefab;
    public Transform spawnPoint;

    [Header("Interval Settings")]
    public float minInterval = 1f;  
    public float maxInterval = 3f;  

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Shoot();

            float randomInterval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    public void Shoot()
    {
        Instantiate(spawnObjectPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
