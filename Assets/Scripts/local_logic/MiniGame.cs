using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private mg_chest_LogicManager mgManager;


    public event Action OnMGCompleted;

    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void Init()
    {
        if (mgManager != null)
        {
            mgManager.OnMGWon += Completed;
        }     
    }
    public void Completed()
    {
        Time.timeScale = 1f;
        OnMGCompleted?.Invoke();
    }
}
