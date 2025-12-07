using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;

    [SerializeField] private AreaController[] areaController;
    [SerializeField] private HealthSystem playerHealthSystem;

    [SerializeField] private GameObject[] objectsToShow;
    [SerializeField] private GameObject[] objectsToHide;

    private int maxWinPoints;
    private int currentWinPoints;

    private void Start()
    {
        foreach (AreaController areaController in areaController)
        {
            if (areaController != null)
            {
                maxWinPoints++;
                areaController.Init();
                areaController.OnAreaCompleted += GetWinPoint;
            }
        }
        Debug.Log($"Max win points in this location : {maxWinPoints}");
        playerHealthSystem.OnPlayerDeadStatus += RestartLevel;
    }
    private void RestartLevel()
    {
        sceneLoader.RestartScene();
    }

    public void GetWinPoint()
    {
        currentWinPoints++;
        Debug.Log($"Current win points in this location : {currentWinPoints}");
        OnWinCheck();
    }

    private void OnWinCheck()
    {
        if (currentWinPoints == maxWinPoints)
        {
            Win();
            Debug.Log("Win!");
        }
    }

    private void Win()
    {
        foreach (GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(true);
        }
    }
}
