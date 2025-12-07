using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private mg_chest_LogicManager mgManager;
    public event Action OnMGCompleted;

    public void Init()
    {
        if (mgManager != null)
        {
            mgManager.OnMGWon += Completed;
        }     
    }
    public void Completed()
    {
        OnMGCompleted?.Invoke();
    }
}
