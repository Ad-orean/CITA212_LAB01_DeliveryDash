using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("you hit something!");
        
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Did you hit something?");
    }
}
