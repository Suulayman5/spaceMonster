using System.Numerics;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] private float moveSpead;
    float backgroundImageWidth;

    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        backgroundImageWidth = sprite.texture.width / sprite.pixelsPerUnit;
        Debug.Log(backgroundImageWidth);

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = (moveSpead * PlayerController.instance.boast) * Time.deltaTime;
        transform.position += new UnityEngine.Vector3(moveX, 0);
        if (Mathf.Abs(transform.position.x) > backgroundImageWidth)
        {
            transform.position = new UnityEngine.Vector3(0f, transform.position.y);
        };
    }
}
