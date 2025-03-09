using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Handles asynchronous scene loading with a loading screen and progress display.
/// </summary>
public class SceneLoader : MonoBehaviour // TODO: add better comments
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _progressText;

    private const float LoadingCompleteThreshold = 0.9f;
    private const float ProgressUpdateInterval = 0.1f;

    /// <summary>
    /// Initiates the loading of a new scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to load.</param>
    public void LoadScene(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    /// <summary>
    /// Coroutine that handles the asynchronous loading of a scene.
    /// </summary>
    /// <param name="sceneIndex">The build index of the scene to load.</param>
    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / LoadingCompleteThreshold);
            UpdateLoadingProgress(progress);
            yield return new WaitForSeconds(ProgressUpdateInterval);
        }
    }

    /// <summary>
    /// Updates the loading progress display.
    /// </summary>
    /// <param name="progress">The current loading progress (0 to 1).</param>
    private void UpdateLoadingProgress(float progress)
    {
        _progressBar.value = progress;
        _progressText.text = $"{progress * 100f:F2}%";
    }
}