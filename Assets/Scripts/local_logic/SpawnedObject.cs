using LazySquirrelLabs.SphereGenerator.Generators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    public string tagProjectile;
    public int damage = 10;
    public float speed = 3f;
    public bool isSphere = false;

    private MeshFilter _meshFilter;

    private void Awake()
    {
        if (isSphere)
        {
            SphereGenerator generator = new IcosphereGenerator(1, 0);
            Mesh mesh = generator.Generate();
            _meshFilter = gameObject.GetComponent<MeshFilter>();
            _meshFilter.mesh = mesh;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagProjectile))
        {
            HealthSystem health = other.gameObject.GetComponent<HealthSystem>();
            health?.GetDamage(damage);
        }
        if (other.gameObject.CompareTag("Blocker"))
        {
            Destroy(gameObject);
        }
    }
}
