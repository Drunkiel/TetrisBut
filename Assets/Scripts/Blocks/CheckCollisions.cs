using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public LayerMask layerMask;

    public float CheckCollision()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
        {
            return hit.distance;
        }
        else return 0;
    }
}
