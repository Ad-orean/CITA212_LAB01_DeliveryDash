using UnityEngine;

public class Driver : MonoBehaviour
{
        void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(0,0,0.5f);
        transform.Translate(0,.05f,0);
    }
}
