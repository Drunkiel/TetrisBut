using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectToFollow;
    public bool followOnlyY;
    public float additionalHeight;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followOnlyY) transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y + additionalHeight, transform.position.z);
        else transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y + additionalHeight, objectToFollow.transform.position.z);
    }
}
