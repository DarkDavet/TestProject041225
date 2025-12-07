using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    [SerializeField] private int areaID;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Checkpoint[] checkpoints;
    [SerializeField] private MiniGame[] miniGame;

    [SerializeField] private GameObject[] objectsToShow;
    [SerializeField] private GameObject[] objectsToHide;

    public event Action OnAreaCompleted;

    private int maxWinPoints;
    private int currentWinPoints;
    public void Init()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Init();
            enemy.OnEnemyDefeated += GetWinPoint;
            maxWinPoints++;
        }

        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.OnCheckpointReached += GetWinPoint;
            maxWinPoints++;
        }

        foreach (MiniGame miniGame in miniGame)
        {
            miniGame.OnMGCompleted += GetWinPoint;
            miniGame.Init();
            maxWinPoints++;
        }
        Debug.Log($"Max win points in area {areaID} : {maxWinPoints}");
    }

    public void GetWinPoint()
    {
        currentWinPoints++;
        Debug.Log($"Current win points in area {areaID} : {currentWinPoints}");
        OnWinCheck();
    }

    private void OnWinCheck()
    {
        if (currentWinPoints == maxWinPoints)
        {
            WinArea();
        }
    }

    private void WinArea()
    {
        foreach (GameObject obj  in objectsToShow)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
        OnAreaCompleted?.Invoke();
     }
}
