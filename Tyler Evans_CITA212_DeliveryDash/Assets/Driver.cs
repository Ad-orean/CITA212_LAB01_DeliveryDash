using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = .25f;
       
    void Update()
    {
        if(Keyboard.current.wKey.isPressed)
        {
            Debug.Log("We are pushing Forward");
        }

         else if(Keyboard.current.aKey.isPressed)
        {
            Debug.Log("We are pushing Left");
        }

         if(Keyboard.current.sKey.isPressed)
        {
            Debug.Log("We are pushing backwards");
        }

         else if(Keyboard.current.dKey.isPressed)
        {
            Debug.Log("We are pushing Right");
        }
        
        
        
        
        
        transform.Rotate(0,0,steerSpeed);
        transform.Translate(0,moveSpeed,0);
    }
}
