using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static int pickedDifficulty;

    public bool[] menusOpen;
    public GameObject[] menus;

    public void OpenCloseMenu(int i)
    {
        menusOpen[i] = !menusOpen[i];
        menus[i].SetActive(menusOpen[i]);
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
