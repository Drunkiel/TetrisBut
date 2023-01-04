using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public int cameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = Mathf.FloorToInt(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfNeedToUpdate();
    }

    void CheckIfNeedToUpdate()
    {
        if (Mathf.Floor(player.position.y) + 4 > cameraHeight + 1)
        {
            cameraHeight++;
            transform.position = new Vector3(0, cameraHeight, -10);
        }

        if(Mathf.Floor(player.position.y) + 4 < cameraHeight)
        {
            cameraHeight--;
            transform.position = new Vector3(0, cameraHeight, -10);
        }
    }
}
