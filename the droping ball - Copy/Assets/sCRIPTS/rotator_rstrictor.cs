using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator_rstrictor : MonoBehaviour
{
    public float Rotaion_restrictio_speed,RotaionRestrictionRight,RotationRestrictionLeft;
    float sign1 = 1f;
  //  public GameObject rotaionHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotaionRestrictionRight * sign1);
        if (transform.rotation.z>RotaionRestrictionRight)
        {
            sign1 = -1;
        }
        else if(transform.rotation.z<RotationRestrictionLeft)
        {
            sign1= 1;
        }
        
    }
}
