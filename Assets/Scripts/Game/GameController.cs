using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool isGameRunning;
    public static float gameMultiplier;

    public TMP_Text title;

    public TMP_Text finalScore;
    public TMP_Text finalHeight;
    public TMP_Text finalLifeTime;

    public GameObject afterGameScreen;

    public void RunGame()
    {
        switch (MainMenuController.pickedDifficulty)
        {
            case 0:
                gameMultiplier = 0.5f;
                break;

            case 1:
                gameMultiplier = 1f;
                break;

            case 2:
                gameMultiplier = 2f;
                break;
        }

        ScoreController.pointsMultiplier = gameMultiplier;

        isGameRunning = true;
        GameObject.FindGameObjectWithTag("Board").GetComponent<BoardController>().spawnBlock = true;
    }

    public void StopGame(bool gameOver)
    {
        isGameRunning = false;

        if (!gameOver)
        {
            title.text = "Winner";
            title.color = new Color32(0, 255, 0, 1);
        }
        else
        {
            title.text = "Gameover";
            title.color = new Color32(255, 0, 0, 1);
            PlayerController.isDead = true;
        }

        ScoreController _scoreController = GetComponent<ScoreController>();
        finalScore.text = _scoreController.score.text;
        finalHeight.text = _scoreController.playerHeight.ToString();
        finalLifeTime.text = _scoreController.lifeTime.text;

        afterGameScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerController.isDead = false;
        ScoreController.points = 0;
    }
}
