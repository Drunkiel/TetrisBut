using UnityEngine;

public class SetHighestPoint : MonoBehaviour
{
    public int highestPoint;
    public float additionalHeight;

    public void CheckHighestPoint(int value)
    {
        if (highestPoint < value)
        {
            highestPoint = value;
            transform.position = new Vector3(0, (highestPoint + additionalHeight) * 1.056f, 0);
        }
    }
}
