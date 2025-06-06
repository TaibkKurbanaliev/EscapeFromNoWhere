using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private SceneTransition _sceneTransition;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private TMP_Text _infoText;

    public static LoadingManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return _sceneTransition.AnimationIn();

        _progressBar.gameObject.SetActive(true);

        do
        {
            _progressBar.SetProgress(scene.progress);
            yield return null;
        } while (scene.progress < 0.9f);

        _progressBar.ShowCompleteButton();
        yield return new WaitUntil(AnyInputDetected);

        scene.allowSceneActivation = true;
        _progressBar.gameObject.SetActive(false);

        yield return _sceneTransition.AnimationOut();
    }

    private bool AnyInputDetected()
    {
        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame) 
            return true;

        if (Mouse.current != null && (Mouse.current.leftButton.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame))
            return true;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            return true;

        if (Gamepad.current != null && Gamepad.current.allControls.Any(control => control is ButtonControl button && button.wasPressedThisFrame))
            return true;

        return false;
    }
}
