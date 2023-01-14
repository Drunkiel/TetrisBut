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

    ParticleController _particleController;
    ParticleSystem runParticle;
    Rigidbody rgBody;

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
        _particleController = GetComponent<ParticleController>();
        runParticle = _particleController.runParticle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(groundTester.position, radius, layerMask);

        if (colliders.Length > 0) onTheGround = true;
        else onTheGround = false;

        if (!isDead)
        {
            Movement();
            Jump();
        }
    }

    void Movement()
    {
        //Initializing inputs
        float x = Input.GetAxis("Horizontal");

        if ((x < 0 || x > 0) && onTheGround && !runParticle.isPlaying) runParticle.Play();
        else if ((x == 0 || !onTheGround) && !runParticle.isStopped) runParticle.Stop();

        //Player movement
        if (onTheGround)
        {
            rgBody.velocity = new Vector2(speedForce * x, rgBody.velocity.y);

            if (x < 0)
            {
                if (dirToRight) RotatePlayer();
                _particleController.RotateParticle(1);
            }

            if (x > 0)
            {
                if (!dirToRight) RotatePlayer();
                _particleController.RotateParticle(-1);
            }
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
        Vector3 playerScale = transform.GetChild(0).localScale;
        playerScale.x *= -1;
        transform.GetChild(0).localScale = playerScale;
    }
}
