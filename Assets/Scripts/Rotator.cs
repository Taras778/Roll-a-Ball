using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

public class PickUp : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
