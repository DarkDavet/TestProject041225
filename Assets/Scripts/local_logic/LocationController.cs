using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private HealthSystem healthSystem;
    private void Start()
    {
       playerMovement.Init();
       healthSystem.Init();
       healthSystem.OnDeadStatus += RestartLevel;
    }

    private void RestartLevel()
    {
        Scene currenScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(currenScene);
    }

    private void Win()
    {
    }
}
