using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    public Transform center;
    public Transform[] blocksToRotate;
    public int[] blockStages;
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
        stages.Add(new Vector3(center.position.x, center.position.y + blockDifference, 0));
        stages.Add(new Vector3(center.position.x + blockDifference, center.position.y + blockDifference, 0));
        stages.Add(new Vector3(center.position.x + blockDifference, center.position.y, 0));
        stages.Add(new Vector3(center.position.x + blockDifference, center.position.y - blockDifference, 0));
        stages.Add(new Vector3(center.position.x, center.position.y - blockDifference, 0));
        stages.Add(new Vector3(center.position.x - blockDifference, center.position.y - blockDifference, 0));
        stages.Add(new Vector3(center.position.x - blockDifference, center.position.y, 0));
        stages.Add(new Vector3(center.position.x - blockDifference, center.position.y + blockDifference, 0));
    }

    void CheckStage()
    {
        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (blocksToRotate[i].position == stages[j])
                {
                    blockStages[i] = j;
                    break;
                }
            }
        }
    }

    public void RotateBlock()
    {
        for (int i = 0; i < blocksToRotate.Length; i++)
        {
            blockStages[i] += 2;
            if (blockStages[i] > 7) blockStages[i] -= 8;

            blocksToRotate[i].position = stages[blockStages[i]];
        }
    }
}
