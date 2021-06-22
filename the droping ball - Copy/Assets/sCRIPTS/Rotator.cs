using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotationVelocity;
    public bool AntiClockWise = true;
    private void Update()
    {
        if(AntiClockWise)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotationVelocity);
        }
    else
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * RotationVelocity);
        }
    }
    
       
}
