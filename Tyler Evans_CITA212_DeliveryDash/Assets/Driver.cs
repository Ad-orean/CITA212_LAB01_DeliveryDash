using UnityEngine;

public class Driver : MonoBehaviour
{

    float steerSpeed = 0.5f;
    float moveSpeed = .25f;
        void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(0,0,steerSpeed);
        transform.Translate(0,moveSpeed,0);
    }
}
