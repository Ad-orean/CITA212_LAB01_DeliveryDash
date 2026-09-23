using NUnit.Framework;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;

    void Start()
    {
        Debug.Log(hasPackage);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Package"))

        {
            Debug.Log("Pickup Package");
            hasPackage = true;
        }

        if(collision.CompareTag("Customer") && hasPackage)

        {
            Debug.Log("Package Delivered");
            hasPackage = false;
        }
    }
}
