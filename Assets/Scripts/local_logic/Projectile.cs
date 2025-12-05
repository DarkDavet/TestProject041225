using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public string tagProjectile;
    public float damage = 10;
    public float lifeTime = 3f;

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
