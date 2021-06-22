using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translation : MonoBehaviour
{
    public bool sidewayss;
    public float velo,constrin1,constrin2;
    float sign=1f;
     void Update()
    {
        if(sidewayss)
        {
            transform.Translate(Vector3.right * velo * Time.deltaTime * sign);
            if (transform.position.x > constrin1)
            {
                sign = -1f;


            }
            else if (transform.position.x < constrin2)
            {
                sign = 1f;
            }
        }
        else
        {
            transform.Translate(Vector3.right * velo * Time.deltaTime * sign);
            if (transform.position.y > constrin1)
            {
                sign = -1f;


            }
            else if (transform.position.y < constrin2)
            {
                sign = 1f;
            }
        }
       

        
    }
}
