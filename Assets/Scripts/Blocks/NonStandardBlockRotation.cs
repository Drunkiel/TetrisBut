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

public class NonStandardBlockRotation : MonoBehaviour
{
    public Transform center;
    public Transform[] blocksToRotate;
    public FieldsToMove[] fieldsToMove;
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
        float blockDifference = 1.056f;

        //Setting stage positions
        //Line 1
        stages.Add(new Vector3(center.localPosition.x - (blockDifference + blockDifference / 2), center.localPosition.y + (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference / 2, center.localPosition.y + (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference / 2, center.localPosition.y + (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x + (blockDifference + blockDifference / 2), center.localPosition.y + (blockDifference + blockDifference / 2), 0));
        //Line 2
        stages.Add(new Vector3(center.localPosition.x - (blockDifference + blockDifference / 2), center.localPosition.y + blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference / 2, center.localPosition.y + blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference / 2, center.localPosition.y + blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x + (blockDifference + blockDifference / 2), center.localPosition.y + blockDifference / 2, 0));
        //Line 3
        stages.Add(new Vector3(center.localPosition.x - (blockDifference + blockDifference / 2), center.localPosition.y - blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference / 2, center.localPosition.y - blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference / 2, center.localPosition.y - blockDifference / 2, 0));
        stages.Add(new Vector3(center.localPosition.x + (blockDifference + blockDifference / 2), center.localPosition.y - blockDifference / 2, 0));
        //Line 4
        stages.Add(new Vector3(center.localPosition.x - (blockDifference + blockDifference / 2), center.position.y - (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x - blockDifference / 2, center.localPosition.y - (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference / 2, center.localPosition.y - (blockDifference + blockDifference / 2), 0));
        stages.Add(new Vector3(center.localPosition.x + (blockDifference + blockDifference / 2), center.localPosition.y - (blockDifference + blockDifference / 2), 0));
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
