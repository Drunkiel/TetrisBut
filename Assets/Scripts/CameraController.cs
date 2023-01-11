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
        if (Mathf.Floor(player.position.y) + 5 > cameraHeight + 1)
        {
            UpdateHeight(1);
        }

        if(Mathf.Floor(player.position.y) + 5 < cameraHeight)
        {
            UpdateHeight(-1);
        }
    }

    void UpdateHeight(int value)
    {
        cameraHeight += value;
        transform.position = new Vector3(0, cameraHeight, -10);
    }
}
