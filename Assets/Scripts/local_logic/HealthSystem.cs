using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private bool isPlayer;

    [SerializeField] private UIHealthStatusWidget uiHealthWidget;

    public event Action OnPlayerDeadStatus;
    public event Action OnEnemyDeadStatus;

    private void Start()
    {
        playerSettings.CurrentHealth = playerSettings.MaxHealth;
        uiHealthWidget.InitWdget(playerSettings.MaxHealth);
        uiHealthWidget.UpdatedWidget(playerSettings.MaxHealth);
    }

    public void GetDamage(int damage)
    {
        Debug.Log("Damage is gotten");
        playerSettings.CurrentHealth -= damage;
        Debug.Log($"{playerSettings.CurrentHealth}");
        uiHealthWidget.UpdatedWidget(playerSettings.CurrentHealth);
        
        if (!isAlive())
        {
            if (isPlayer)
            {
                OnPlayerDeadStatus?.Invoke();
            }
            OnEnemyDeadStatus?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            OnPlayerDeadStatus?.Invoke();
        }
    }

    private bool isAlive()
    {
        if (playerSettings.CurrentHealth <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
