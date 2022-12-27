using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static int pickedDifficulty;

    public bool isDifficultyMenuOpen;
    public GameObject difficultyMenu;

    public void PlayButtonButton()
    {
        isDifficultyMenuOpen = !isDifficultyMenuOpen;
        difficultyMenu.SetActive(isDifficultyMenuOpen);
    }

    public void PlayModeButton(int difficulty)
    {
        pickedDifficulty = difficulty;
        SceneManager.LoadScene(1);
    }

    public void LeaveGameButton()
    {
        Application.Quit();
    }
}
