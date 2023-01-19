using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text height;
    public TMP_Text lifeTime;
    public TMP_Text multiplier;

    public static int points;
    public static float pointsMultiplier = 0;
    public int playerHeight;
    public float livingTime;

    public static float timeBeforeReset;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isGameRunning)
        {
            Timer();
            CheckPlayerHeight();
            score.text = points.ToString();
            multiplier.text = "x" + pointsMultiplier.ToString();
        }
    }

    public static void AddScore(int value)
    {
        points += Mathf.RoundToInt(value * pointsMultiplier);
    }

    void Timer()
    {
        livingTime += Time.deltaTime;

        if (pointsMultiplier >= 1)
        {
            if (timeBeforeReset > 0) timeBeforeReset -= Time.deltaTime;
            else pointsMultiplier = GameController.gameMultiplier;
        }

        float timeToDisplay = Mathf.Floor(livingTime);
        lifeTime.text = timeToDisplay.ToString() + "s";
    }

    void CheckPlayerHeight()
    {
        playerHeight = Mathf.FloorToInt(player.transform.position.y) + 4;
        height.text = playerHeight.ToString();
    }
}
