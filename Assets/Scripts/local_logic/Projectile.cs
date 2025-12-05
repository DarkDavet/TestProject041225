using LazySquirrelLabs.SphereGenerator.Generators;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;

    public string tagProjectile;
    public float damage = 10;
    public float lifeTime = 3f;
    

    private void Awake()
    {
        SphereGenerator generator = new IcosphereGenerator(1, 0);
        Mesh mesh = generator.Generate();
        _meshFilter.mesh = mesh;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagProjectile))
        {
            HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();
            health?.GetDamage(10);
        }
        Destroy(gameObject);
    }
}
