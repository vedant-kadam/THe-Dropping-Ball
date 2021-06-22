using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControlOnScreen : MonoBehaviour
{

    public float PaddleSpeed,xpositionClamp,YpositionClamp;
    float screenWidth;
    Vector3 CurrentPosition;
    private void Start()
    {
        screenWidth = Screen.width ;        
    }
    private void Update()
    {
        CurrentPosition = transform.position;
        CurrentPosition.x = Mathf.Clamp(CurrentPosition.x, -xpositionClamp, xpositionClamp);
        CurrentPosition.y = Mathf.Clamp(CurrentPosition.y, YpositionClamp, YpositionClamp);
        transform.position = CurrentPosition;

        if(Input.GetTouch(0).position.x>screenWidth/2)
        {
            transform.Translate(Vector3.right * Time.deltaTime * PaddleSpeed);
            //MoveRight
        }else if(Input.GetTouch(0).position.x<screenWidth/2)
        {
            //MoveLeft
            transform.Translate(-Vector3.right * Time.deltaTime * PaddleSpeed);

        }
    }
}
