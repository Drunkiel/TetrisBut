using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float cooldown;
    private float resCooldown;
    public int directionToMove;
    private Transform player;

    public CheckCollisions[] _checkCollisions;
    BlockController _blockController;

    // Start is called before the first frame update
    void Start()
    {
        resCooldown = cooldown;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _blockController = GetComponent<BlockController>();
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
            if (cooldown > 2) Movement();
            cooldown -= Time.deltaTime;
        }
    }

    bool CheckIfWall(bool left, bool right)
    {
        bool[] ifTrue = new bool[_checkCollisions.Length];

        for (int i = 0; i < ifTrue.Length; i++)
        {
            if (left) ifTrue[i] = _checkCollisions[i].CheckWallLeftCollision();
            if (right) ifTrue[i] = _checkCollisions[i].CheckWallRightCollision();

            if (ifTrue[i]) return true;
        }

        return false;
    }

    void CalculateDistanceToFall()
    {
        float[] distances = new float[_checkCollisions.Length];
        float nearestBlock = 10;

        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = _checkCollisions[i].CheckGroundCollision();
        }

        int zeroAppearance = 0;
        for (int i = 0; i < distances.Length; i++)
        {
            if (Mathf.Floor(distances[i]) == 0)
            {
                zeroAppearance++;
                if (zeroAppearance >= 1) _blockController.AutoDestroy();
            }
            else if (Mathf.Floor(distances[i]) < nearestBlock && Mathf.Floor(distances[i]) != 0) nearestBlock = distances[i];
        }

        transform.Translate(0, -1.058f * Mathf.Floor(nearestBlock), 0);

        _blockController.SetBlocksToBoard();
        _blockController.AutoDestroy();
    }

    void Movement()
    {
        float blockDifference = 1.056f;
        float playerX = 0;

        if (TryGetComponent<BlockRotation>(out BlockRotation _blockRotation)) playerX = Mathf.Floor(player.position.x - _blockRotation.center.position.x);
        else if (TryGetComponent<NonStandardBlockRotation>(out NonStandardBlockRotation _nonStandardBlockRotation)) playerX = Mathf.Floor(player.position.x - _nonStandardBlockRotation.center.position.x);

        if (playerX >= Mathf.Floor(blockDifference))
        {
            if (CheckIfWall(false, true)) return;
            directionToMove = 1;
        }
        else if (playerX < Mathf.Floor(-blockDifference / 2) && playerX != 0)
        {
            if (CheckIfWall(true, false)) return;
            directionToMove = -1;
        }
        else directionToMove = 0;

        transform.position = new Vector3(transform.position.x + blockDifference * directionToMove, transform.position.y, 0);
    }
}

