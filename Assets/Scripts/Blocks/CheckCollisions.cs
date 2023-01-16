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

    public bool CheckPlayerCollision(float value)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), value, layerMask[2]))
        {
            return true;
        }
        else return false;
    }

    public bool CheckWallLeftCollision(int lenght)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), lenght, layerMask[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckWallRightCollision(int lenght)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), lenght, layerMask[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
