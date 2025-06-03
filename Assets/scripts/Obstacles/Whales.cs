using UnityEngine;

public class Whales : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


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
