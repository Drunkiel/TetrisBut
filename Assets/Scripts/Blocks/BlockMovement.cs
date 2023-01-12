using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float cooldown;
    private float resCooldown;
    public float timeToStop;
    public int directionToMove;
    public Transform player;

    public CheckCollisions[] _checkCollisions;
    BlockController _blockController;
    public float blockDifference = 1.056f;

    // Start is called before the first frame update
    void Start()
    {
        resCooldown = cooldown;
        _blockController = GetComponent<BlockController>();

        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch (System.Exception)
        {
            _blockController.AutoDestroy(false);
            Destroy(GetComponent<BlockController>());
        }
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
            if (cooldown > timeToStop) Movement();
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

    bool CheckIfPlayer(float value)
    {
        bool[] ifTrue = new bool[_checkCollisions.Length];

        for (int i = 0; i < _checkCollisions.Length; i++)
        {
            ifTrue[i] = _checkCollisions[i].CheckPlayerCollision(value);
            if (ifTrue[i]) return true;
        }

        return false;
    }

    void CalculateDistanceToFall()
    {
        float[] distances = new float[_checkCollisions.Length];
        float nearestBlock = 100;

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
                if (zeroAppearance >= 1) _blockController.AutoDestroy(true);
            }
            else if (Mathf.Floor(distances[i]) < nearestBlock && Mathf.Floor(distances[i]) != 0) nearestBlock = distances[i];
        }

        if (nearestBlock >= 10) nearestBlock -= 1;

        if (CheckIfPlayer(nearestBlock)) GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>().StopGame(true);
        transform.Translate(0, -blockDifference * Mathf.Floor(nearestBlock), 0);

        SetToCheck();
        _blockController.SetBlocksToBoard();
        _blockController.AutoDestroy(true);
    }

    void Movement()
    {
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

    void SetToCheck()
    {
        CheckBlocksRow _checkBlocksRow = GameObject.FindGameObjectWithTag("Board").transform.GetChild(1).GetComponent<CheckBlocksRow>();
        _checkBlocksRow.blocksHeight.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name != "Center") _checkBlocksRow.blocksHeight.Add(transform.GetChild(i).transform.position.y);
        }

        _checkBlocksRow.check = true;
    }
}

