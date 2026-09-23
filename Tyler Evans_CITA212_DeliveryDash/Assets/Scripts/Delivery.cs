using NUnit.Framework;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float delay = 1f;

    void Start()
    {
        Debug.Log(hasPackage);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Package") && !hasPackage)

        {
            Debug.Log("Picked up Package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }

        if(collision.CompareTag("Customer") && hasPackage)

        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
