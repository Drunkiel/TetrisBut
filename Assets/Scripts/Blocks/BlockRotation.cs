using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    public Transform center;
    public Transform[] blocksToRotate;
    public int[] blockStages;
    public CheckCollisions[] _checkCollisions;
    public List<Vector3> stages = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        blockStages = new int[blocksToRotate.Length];
        SetStages();
        CheckStage();
    }

    void SetStages()
    {
        float blockDifference = 1.056f;

        //Setting stage positions
        stages.Add(new Vector3(center.localPosition.x, center.localPosition.y + blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y + blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y - blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x, center.localPosition.y - blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y - blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y, 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y + blockDifference, 0));
    }

    void CheckStage()
    {
        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (blocksToRotate[i].localPosition == stages[j])
                {
                    blockStages[i] = j;
                    break;
                }
            }
        }
    }

    public void RotateBlock()
    {
        BlockMovement _blockMovement = GetComponent<BlockMovement>();

        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            if(_blockMovement._checkCollisions[i].CheckWallLeftCollision(1)) transform.position = new Vector3(transform.position.x + _blockMovement.blockDifference, transform.position.y, 0);
            if(_blockMovement._checkCollisions[i].CheckWallRightCollision(1)) transform.position = new Vector3(transform.position.x - _blockMovement.blockDifference, transform.position.y, 0);

            blockStages[i] += 2;
            if (blockStages[i] > 7) blockStages[i] -= 8;

            blocksToRotate[i].localPosition = stages[blockStages[i]];
        }
    }
}
