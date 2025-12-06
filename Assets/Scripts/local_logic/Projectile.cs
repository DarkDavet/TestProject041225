using LazySquirrelLabs.SphereGenerator.Generators;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public string tagProjectile;
    public int damage = 10;
    public float lifeTime = 3f;
    public bool isSphere = false;
    public bool isObstacle = false;

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

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagProjectile))
        {
            HealthSystem health = other.gameObject.GetComponent<HealthSystem>();
            health?.GetDamage(damage);
        }
        if (!isObstacle)
        {
            Destroy(gameObject);
        }       
    }
}
