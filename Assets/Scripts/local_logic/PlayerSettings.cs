using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerSettings", menuName = "Player/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [Range(0, 100)][SerializeField] private int maxHealth;
    
    [Range(0, 100)] private int currentHealth;

    public int MaxHealth { get => maxHealth; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = Mathf.Clamp(value, 0, maxHealth); }

    
}
