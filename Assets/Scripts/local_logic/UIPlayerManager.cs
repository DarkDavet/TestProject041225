using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private bool isPlayer;

    [SerializeField] private UIHealthStatusWidget uiHealthWidget;

    public void Init()
    {
        uiHealthWidget.InitWdget(playerSettings.MaxHealth);
        uiHealthWidget.UpdatedWidget(playerSettings.MaxHealth);
    }

    public void GetDamage(int damage)
    {
        playerSettings.CurrentHealth -= damage;
        uiHealthWidget.UpdatedWidget(playerSettings.CurrentHealth);
        
        if (!isAlive())
        {
            if (isPlayer)
            {

            }
            Destroy(gameObject);
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
