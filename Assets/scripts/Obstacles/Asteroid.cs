using Unity.VisualScripting;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    [SerializeField] private Sprite[] sprites;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        float pushX = Random.Range(-1f, 0);
        float pushY = Random.Range(-1f, 1f);

        rb.linearVelocity = new Vector2(pushX, pushY).normalized * Random.Range(1f, 3f);
     
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = (GameManager.instance.worldSpeed * PlayerController.instance.boast) * Time.deltaTime;
        transform.position += new Vector3(-moveX, 0);
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
