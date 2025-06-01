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
    private bool boosting = false;
     private float energy = 50f;
    [SerializeField] private float energyRegen;
     private float maxEnergy = 50f;

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
        energy = maxEnergy;
        UIController.instance.UpdateEnergySlider(energy, maxEnergy);
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

        if (boosting)
        {
            if (energy >= 0.2f)
            {
                energy -= 1f * Time.deltaTime;
            }
            else
            {
                ExitBoast();
            }
        }
        else
        {
            if (energy < maxEnergy)
            {
                energy += energyRegen * Time.deltaTime;
            }
        }
        UIController.instance.UpdateEnergySlider(energy, maxEnergy);

    }
    void EnterBoast()
    {
        if (energy > 10)
        {      
            animator.SetBool("bosting", true);
            boast = boastPower;
            boosting = true;
        }
        else
        {
            ExitBoast();
            Debug.Log("Not enough energy to boast");
        }
    }
    void ExitBoast()
    {
        animator.SetBool("bosting", false);
        boast = 1f;
        boosting = false;
    }
    
}
