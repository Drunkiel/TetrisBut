using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float cooldown;
    private float resCooldown;
    public int directionToMove;
    private Transform player;

    public CheckCollisions[] _checkCollisions;

    // Start is called before the first frame update
    void Start()
    {
        resCooldown = cooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0)
        {
            CalculateDistanceToFall();
            cooldown = resCooldown;
        }
        else
        {
            if(cooldown > 1) Movement();
            cooldown -= Time.deltaTime;
        }
    }

    void CalculateDistanceToFall()
    {
        float[] distances = new float[_checkCollisions.Length];
        float nearestBlock = 10;

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = _checkCollisions[i].CheckCollision();
        }

        int zeroAppearance = 0;
        for (int i = 0; i < distances.Length; i++)
        {
            if (Mathf.Floor(distances[i]) == 0)
            {
                zeroAppearance++;
                if (zeroAppearance >= 1) Destroy(GetComponent<BlockMovement>());
            }
            else if (Mathf.Floor(distances[i]) < nearestBlock && Mathf.Floor(distances[i]) != 0) nearestBlock = distances[i];
        }

        transform.Translate(0, -1.058f * Mathf.Floor(nearestBlock - 1), 0);
    }

    void Movement()
    {
        float blockDifference = 1.056f;
        float playerX = Mathf.Floor(player.position.x - GetComponent<BlockRotation>().center.position.x);

        if (playerX >= Mathf.Floor(blockDifference))
        {
            directionToMove = 1;
        }
        else if (playerX < Mathf.Floor(-blockDifference/2) && playerX != 0)
        {
            directionToMove = -1;
        }
        else directionToMove = 0;

        transform.position = new Vector3(transform.position.x + blockDifference * directionToMove, transform.position.y, 0);
    }
}

