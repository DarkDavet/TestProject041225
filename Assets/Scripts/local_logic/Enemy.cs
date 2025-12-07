using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action OnEnemyDefeated;
    private HealthSystem healthSystem;

    public void Init()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnEnemyDeadStatus += Defeated;
    }
    public void Defeated()
    {
        OnEnemyDefeated?.Invoke();
    }
}
