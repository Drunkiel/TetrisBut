using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class FieldsToMove
{
    public int step1;
    public int step2;
    public int step3;
    public int step4;
}

public class BlockRotation : MonoBehaviour
{
    public Transform center;
    public Transform[] blocksToRotate;
    public FieldsToMove[] fieldsToMove;
    public int lenghtToCheck;
    public int[] blockStages;
    private int step;
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
        if (TryGetComponent<SetStage3x3>(out SetStage3x3 _setStage3)) _setStage3.SetStages();
        else if (TryGetComponent<SetStage4x4>(out SetStage4x4 _setStage4)) _setStage4.SetStages();
    }

    void CheckStage()
    {
        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            for (int j = 0; j < 16; j++)
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
            if (_blockMovement._checkCollisions[i].CheckWallLeftCollision(lenghtToCheck)) transform.position = new Vector3(transform.position.x + _blockMovement.blockDifference, transform.position.y, 0);
            if (_blockMovement._checkCollisions[i].CheckWallRightCollision(lenghtToCheck)) transform.position = new Vector3(transform.position.x - _blockMovement.blockDifference, transform.position.y, 0);
        }

        switch (step)
        {
            case 0:
                blockStages[0] = fieldsToMove[0].step1;
                blockStages[1] = fieldsToMove[0].step2;
                blockStages[2] = fieldsToMove[0].step3;
                blockStages[3] = fieldsToMove[0].step4;
                break;

            case 1:
                blockStages[0] = fieldsToMove[1].step1;
                blockStages[1] = fieldsToMove[1].step2;
                blockStages[2] = fieldsToMove[1].step3;
                blockStages[3] = fieldsToMove[1].step4;
                break;

            case 2:
                blockStages[0] = fieldsToMove[2].step1;
                blockStages[1] = fieldsToMove[2].step2;
                blockStages[2] = fieldsToMove[2].step3;
                blockStages[3] = fieldsToMove[2].step4;
                break;

            case 3:
                blockStages[0] = fieldsToMove[3].step1;
                blockStages[1] = fieldsToMove[3].step2;
                blockStages[2] = fieldsToMove[3].step3;
                blockStages[3] = fieldsToMove[3].step4;
                break;
        }

        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            blocksToRotate[i].localPosition = stages[blockStages[i]];
        }

        if (step >= 3) step = 0;
        else step++;
    }
}
