using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public LayerMask[] layerMask;

    public float CheckGroundCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask[0]))
        {
            return hit.distance;
        }
        else return 0;
    }

    public bool CheckWallLeftCollision()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), 1, layerMask[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckWallRightCollision()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), 1, layerMask[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
