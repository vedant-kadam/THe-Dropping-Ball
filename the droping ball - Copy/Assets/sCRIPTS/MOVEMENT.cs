using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MOVEMENT : MonoBehaviour
{
    public float temp=100f;
    public float xmov=10f,ymov=10f,xclmapEndPoint=2.2f,yclampEndpoint;
    float x, y=0f;
    public bool test;
    private void Start()
    {
        xmov= PlayerPrefs.GetFloat("platformSpeedss",7f);
        ymov = PlayerPrefs.GetFloat("platformRotation", 90f);
    }
    void Update()
    {
        GetInputs();
        xshift();
        rotateions();
        if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            rotateionsanticlock1();
        }
        else if (CrossPlatformInputManager.GetAxis("Vertical") < 0)
        {
            rotateionsclok1();
        }
        else
        {
            y = 0;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
    void GetInputs()
    {
      //  y += CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * ymov;
        x = CrossPlatformInputManager.GetAxis("Horizontal") * xmov * Time.deltaTime;
       // x = Input.GetAxis("Horizontal") * xmov * Time.deltaTime;
      //  y += Input.GetAxis("Vertical") * Time.deltaTime * ymov;
    }
  public   void rotateionsanticlock1()
    {
        y = Time.deltaTime * ymov + transform.eulerAngles.z;
        y = Mathf.Clamp(y, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, 0f, y);
    }
  public  void rotateionsclok1()
    {
        y += -Time.deltaTime * ymov;
        y = Mathf.Clamp(y, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, 0f, y);
    }
    void rotateions()
    {


       
        


           
       
            print(y);
        y = Mathf.Clamp(y, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, 0f, y)
;        
      


    }

     void xshift()
    {
      
 
      
       print(x);
        
        float yposs = transform.position.y;
        yposs = Mathf.Clamp(yposs, yclampEndpoint, yclampEndpoint);
        transform.position = transform.position + Vector3.right * x;
        







        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xclmapEndPoint, xclmapEndPoint),yposs , transform.position.z);
    }
}
