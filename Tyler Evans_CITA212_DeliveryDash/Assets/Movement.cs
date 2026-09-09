using NUnit.Framework.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected" + collision.gameObject.name);
        if(collision.collider.CompareTag("Test"))
        {
            Debug.Log("Collision with Test");
        }
    }
}
