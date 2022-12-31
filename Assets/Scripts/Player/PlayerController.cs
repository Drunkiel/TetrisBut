using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedForce;
    public float jumpForce;

    public float radius;
    public bool onTheGround;
    public Transform groundTester;
    public LayerMask layerMask;

    Rigidbody rgBody;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(groundTester.position, radius, layerMask);

        if (colliders.Length > 0) onTheGround = true;
        else onTheGround = false;

        Movement();
        Jump();

        RotatePlayer();
    }

    void Movement()
    {
        //Initializing inputs
        float x = Input.GetAxis("Horizontal");

        //Player movement
        if(onTheGround)
        {
            rgBody.velocity = new Vector2(speedForce * x, rgBody.velocity.y);

            if (x > 0 || x < 0) anim.Play("Run");
            else anim.Play("Nothing");
        }
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && onTheGround)
        {
            rgBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void RotatePlayer()
    {
        transform.Rotate(0, 180, 0);
    }
}
