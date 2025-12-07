using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel1Scene()
    {
        StartCoroutine(LoadAndStartLevel1());
    } 

    public void LoadMainMenuScene()
    {
        StartCoroutine(LoadAndStartMainMenu());
    }

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    private IEnumerator LoadAndStartLevel1()
    {
        yield return Load(Scenes.LEVEL_1);
        yield return new WaitForSeconds(2);

    }

    private IEnumerator LoadAndStartMainMenu()
    {
        yield return Load(Scenes.MAIN_MENU);
        yield return new WaitForSeconds(2);

    }

    private IEnumerator Load(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
