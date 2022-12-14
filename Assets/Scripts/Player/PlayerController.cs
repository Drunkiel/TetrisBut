using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedForce;
    public float jumpForce;

    public bool onTheGround;
    public Transform groundTester;
    public LayerMask layerMask;

    Rigidbody rgBody;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(groundTester.position, 0.51f, layerMask);

        if (colliders.Length > 0) onTheGround = true;
        else onTheGround = false;

        Movement();
        Jump();
    }

    void Movement()
    {
        //Initializing inputs
        float x = Input.GetAxis("Horizontal");

        //Player movement
        if(onTheGround) rgBody.velocity = new Vector2(speedForce * x, rgBody.velocity.y);
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && onTheGround)
        {
            rgBody.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
