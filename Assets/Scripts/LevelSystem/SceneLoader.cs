using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    [Inject(Id = "LoadingScreen")]
    private Canvas _loadingScreen;

    private AsyncOperation _loadingOperation;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadScene(string sceneName)
    {
        _loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(LoadCourotin());
    }

    private IEnumerator LoadCourotin()
    {
        _loadingScreen.gameObject.SetActive(true);

        while (!_loadingOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        _loadingScreen.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
