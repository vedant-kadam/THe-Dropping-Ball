using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TEMPmOVEMENT : MonoBehaviour
{
    
    public float temp1 = 100f;
    public float xmov1 = 10f, ymov1 = 10f, xclmapEndPoint1= 2.2f,yclampendpoint1;
    float x1, y1 = 0f;
    public bool tes1t=false;
    public float speedss=100f;
    float y2;
    void Update()
    {
        if (y1 == 0f)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0f, 0f), speedss);
        }
        GetInputs();
        xshift();
        if(Input.GetAxis("Vertical")>0)
        {
            rotateionsanticlock();
        }else if(Input.GetAxis("Vertical") < 0)
        {
            rotateionsclok();
        }
        else
        {
            y1 = 0;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
      //  rotateions();
       // transform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
    }
    void GetInputs()
    {
        
        
         x1 = Input.GetAxis("Horizontal") * xmov1 * Time.deltaTime;
       //  y1 =  Time.deltaTime * ymov1+transform.eulerAngles.z;
       // y2 = Input.GetAxis("Vertical");
       
        
           // transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0f, 0f), speedss);
        
    }
    void rotateionsanticlock()
    {


        y1 = Time.deltaTime * ymov1 + transform.eulerAngles.z;

        tes1t = true;



        print(y1);
        y1 = Mathf.Clamp(y1, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, 0f, y1);
            BringtoNormal(true);

       // y1 = 0;



    }
    void rotateionsclok()
    {
        y1 += -Time.deltaTime * ymov1 ;

      //  tes1t = true;



      //  print(y1);
        y1 = Mathf.Clamp(y1, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, 0f, y1);
    //    BringtoNormal(true);
        //y1 = 0;
    }
    void BringtoNormal(bool getit)
    {
       
    }

    void xshift()
    {



        print(x1);

        float yposs1 = transform.position.y;
        yposs1 = Mathf.Clamp(yposs1, yclampendpoint1, yclampendpoint1);
        transform.position = transform.position + Vector3.right * x1;








        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xclmapEndPoint1, xclmapEndPoint1), yposs1, transform.position.z);
    }
}
