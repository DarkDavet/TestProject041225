using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour
{
    private void RestartLevel()
    {
        Scene currenScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(currenScene);
    }

    private void Win()
    {
    }
}
