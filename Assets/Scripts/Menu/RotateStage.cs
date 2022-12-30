using UnityEngine;

public class RotateStage : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Rotate(); 
    }

    void Rotate()
    {
        if (transform.rotation.y == 360f)
        {
            ResetRotation();
        }

        transform.Rotate(0, speed, 0);
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
