using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedForce;
    public float jumpForce;
    private bool dirToRight;

    public float radius;
    public bool onTheGround;
    public Transform groundTester;
    public LayerMask layerMask;
    public static bool isDead;

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

        if(!isDead)
        {
            Movement();
            Jump();
        }
        else
        {
            anim.Play("Death");
        }
    }

    void Movement()
    {
        //Initializing inputs
        float x = Input.GetAxis("Horizontal");

        //Player movement
        if (onTheGround)
        {
            rgBody.velocity = new Vector2(speedForce * x, rgBody.velocity.y);

            if (x > 0 || x < 0) anim.Play("Run");
            else anim.Play("Nothing");

            if (x < 0 && dirToRight) RotatePlayer();
            else if (x > 0 && !dirToRight) RotatePlayer();
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
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
    }
}
