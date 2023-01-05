using UnityEngine;

public class FollowCameraHeight : MonoBehaviour
{
    public Transform gameCamera;
    public float additionalHeight;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, gameCamera.transform.position.y + additionalHeight, transform.position.z);
    }
}
