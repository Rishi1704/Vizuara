using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrbitPoint : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    private Vector3 lastMousePosition;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            lastMousePosition = Input.mousePosition;
        
        if(Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            
            Vector3 movement = Camera.main.transform.right * delta.x + Camera.main.transform.forward * delta.y;
            movement.y = 0f;
            transform.position += movement * Time.deltaTime;
            cam.transform.position += movement * Time.deltaTime;
            lastMousePosition = Input.mousePosition;
        }
    }
}
