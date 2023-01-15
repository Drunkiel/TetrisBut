using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text height;
    public TMP_Text lifeTime;

    public static int points;
    public static float pointsMultiplier;
    public int playerHeight;
    public float livingTime;

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
        }
    }

    public static void AddScore(int value)
    {
        points += Mathf.RoundToInt(value * pointsMultiplier);
    }

    void Timer()
    {
        livingTime += Time.deltaTime;

        int timeToDisplay = Mathf.FloorToInt(livingTime % 60);
        lifeTime.text = timeToDisplay.ToString();
    }

    void CheckPlayerHeight()
    {
        playerHeight = Mathf.FloorToInt(player.transform.position.y) + 4;
        height.text = playerHeight.ToString();
    }
}
