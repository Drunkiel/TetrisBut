using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour
{
    public bool isMusicMuted;

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveGameButton()
    {
        Application.Quit();
    }
}
