using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 playerDirection;
    private float moveSpeed = 4f;
    public float boast = 1f;
    private float boastPower = 5f;

        private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        float direactionX = Input.GetAxisRaw("Horizontal");
        float direactionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(direactionX, direactionY).normalized;
        animator.SetFloat("moveX", direactionX);
        animator.SetFloat("moveY", direactionY);
        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Space))
        {
            // animator.SetBool("Bosting", true);
            EnterBoast();
        }
        else if (Input.GetButtonUp("Fire2") || Input.GetKeyUp(KeyCode.Space))
        {
            // animator.SetBool("Bosting", false);
            ExitBoast();
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerDirection.x, playerDirection.y) * moveSpeed;
    }
    void EnterBoast()
    {
        animator.SetBool("bosting", true);
        boast = boastPower;

    }
    void ExitBoast()
    {
        animator.SetBool("bosting", false);
        boast = 1f;

    }
    
}
