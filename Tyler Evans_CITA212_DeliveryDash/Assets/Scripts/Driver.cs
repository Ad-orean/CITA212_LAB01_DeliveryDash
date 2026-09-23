using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float currentSpeed = .25f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;
    [SerializeField] float deliverySpeed = 7f;

    [SerializeField] TMP_Text boostText;
    [SerializeField] TMP_Text statusText;

    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color packageColor = Color.yellow;
    [SerializeField] Color deliveredColor = Color.green;

    SpriteRenderer sr;
    bool hasPackage = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = normalColor;

        boostText.gameObject.SetActive(false);
        statusText.text = "";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            hasPackage = true;
            Destroy(collision.gameObject);
            statusText.text = "Package Picked Up!";
            currentSpeed = regularSpeed;
            sr.color = packageColor;
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            Destroy(collision.gameObject);
            statusText.text = "Delivery Complete!";
            currentSpeed = deliverySpeed;
            sr.color = deliveredColor;
        }

        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Slow"))
        {
            currentSpeed = regularSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
        sr.color = normalColor;
    }

    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if (Keyboard.current.wKey.isPressed) move = 1f;
        else if (Keyboard.current.sKey.isPressed) move = -1f;

        if (Keyboard.current.aKey.isPressed) steer = 1f;
        else if (Keyboard.current.dKey.isPressed) steer = -1f;

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
