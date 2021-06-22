using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upsideway : MonoBehaviour
{
    public float upwardSpeed,upwardConstrain1,UpwardConstrain2;
    float sign=1;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up *upwardSpeed * Time.deltaTime * sign);
        if (transform.position.y >upwardConstrain1)
        {
            sign = -1f;


        }
        else if (transform.position.y < UpwardConstrain2)
        {
            sign = 1f;
        }
    }
}
