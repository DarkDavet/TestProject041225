using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, IShooting
{
    public GameObject spawnObjectPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void Shoot()
    {
        GameObject spawnObject = Instantiate(spawnObjectPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
