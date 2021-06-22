using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSCript : MonoBehaviour
{
    float xmov, ymov;
    public float xpeeds=5.5f, yspeeds=60f,xclmap,yclmaps,rotionclmap;
    private void Update()
    {
        xmov = Input.GetAxis("Horizontal") * xpeeds * Time.deltaTime;
        ymov += Input.GetAxis("Vertical") * yspeeds * Time.deltaTime;


        ymov = Mathf.Clamp(ymov, -rotionclmap, rotionclmap);
        
        transform.position = new Vector3(xmov, 0f, 0f) + transform.position;
        Vector3 temppoi = transform.position;
        temppoi.x = Mathf.Clamp(temppoi.x, -xclmap, xclmap);
        temppoi.y = Mathf.Clamp(temppoi.y, yclmaps, yclmaps);
        transform.position = temppoi;
        transform.eulerAngles = new Vector3(0f, 0f, ymov);
    }
}
