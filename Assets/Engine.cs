using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(-this.transform.forward * Time.deltaTime * speed, ForceMode.Force);
        }        
    }
    
}
