using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void HandleNewGame()
    {
        LoadingManager.Instance.LoadScene("PlayMode");
    }
}
