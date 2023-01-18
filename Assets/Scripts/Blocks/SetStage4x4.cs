using System.Collections.Generic;
using UnityEngine;

public class SetStage4x4 : MonoBehaviour
{
    public void SetStages()
    {
        float blockDifference = GetComponent<BlockMovement>().blockDifference;

        BlockRotation _blockRotation = GetComponent<BlockRotation>();
        List<Vector3> stages = _blockRotation.stages;
        Transform center = _blockRotation.center;

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

        _blockRotation.stages = stages;
    }
}
