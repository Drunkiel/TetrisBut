using System.Collections.Generic;
using UnityEngine;

public class SetStage3x3 : MonoBehaviour
{
    public void SetStages()
    {
        float blockDifference = GetComponent<BlockMovement>().blockDifference;

        BlockRotation _blockRotation = GetComponent<BlockRotation>();
        List<Vector3> stages = _blockRotation.stages;
        Transform center = _blockRotation.center;

        //Setting stage positions
        //line 1
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y + blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x, center.localPosition.y + blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y + blockDifference, 0));

        //line 2
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y, 0));
        stages.Add(new Vector3(center.localPosition.x, center.localPosition.y, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y, 0));

        //line 3
        stages.Add(new Vector3(center.localPosition.x - blockDifference, center.localPosition.y - blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x, center.localPosition.y - blockDifference, 0));
        stages.Add(new Vector3(center.localPosition.x + blockDifference, center.localPosition.y - blockDifference, 0));

        _blockRotation.stages = stages;
    }
}
