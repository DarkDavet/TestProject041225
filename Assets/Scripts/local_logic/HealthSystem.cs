using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private bool isPlayer;

    [SerializeField] private UIHealthStatusWidget uiHealthWidget;

    public event Action OnDeadStatus;

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
                OnDeadStatus?.Invoke();
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            OnDeadStatus?.Invoke();
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
