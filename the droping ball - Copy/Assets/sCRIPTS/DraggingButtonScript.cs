
using UnityEngine;
using UnityEngine.UI;

public class DraggingButtonScript : MonoBehaviour
{
    private Touch touch;
    public float dragModifier = 0.01f;
    public bool dragit = false,dragitRight=false,dragitClock=false,dragitAntiClock=false;
    public Slider Sensitivity_of_Platform,SenstivityOfPlatformRotation;
  //  public GameObject touchregister;
  
    public GameObject LeftSlide, Rightslide, ClockSlide, AntiClockSlide;//slidds
    public GameObject left1, right1, clock1, anticlock1;//actual obj
    public Color mYCOLOUR;
    
    private void Start()
    {
        //giing position 
        PlayerPrefs.GetFloat("LeftX", -284f);
        PlayerPrefs.GetFloat("LeftY", -467.02f);
        PlayerPrefs.GetFloat("RightX", -80f);
        PlayerPrefs.GetFloat("RightY", -467.02f);
        PlayerPrefs.GetFloat("AntiX", 287.38f);
        PlayerPrefs.GetFloat("AntiY", -401.99f);
        dragit = dragitRight = dragitClock = dragitAntiClock = false;
        //assigh the values at start if are updated ,updated values will be their if not then defaylt values will be given
        //Left
       left1.GetComponent<RectTransform>().localPosition =  new Vector3(PlayerPrefs.GetFloat("LeftX", -284f), PlayerPrefs.GetFloat("LeftY", -467.02f), 0f);
        //Right
      right1.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("RightX", -80f), PlayerPrefs.GetFloat("RightY", -467.02f), 0f);
   //     //Clock Wise 
     clock1.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("ClockX", 287.38f), PlayerPrefs.GetFloat("ClockY", -583f), 0f);
        //ANticlockWise
   anticlock1.GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefs.GetFloat("AntiX", 287.38f), PlayerPrefs.GetFloat("AntiY", -401.99f), 0f);

        //giving the scale to the left right clock and anti clock button
        left1.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleLeft", 1.35f), PlayerPrefs.GetFloat("ScaleLeft", 1.35f),
                                                                               PlayerPrefs.GetFloat("ScaleLeft", 1.35f));
       right1.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleRight", 1.35f), PlayerPrefs.GetFloat("ScaleRight", 1.35f),
                                                                              PlayerPrefs.GetFloat("ScaleRight", 1.35f));
        clock1.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleClock", 1.35f), PlayerPrefs.GetFloat("ScaleClock", 1.35f),
                                                                              PlayerPrefs.GetFloat("ScaleClock", 1.35f));
        anticlock1.GetComponent<RectTransform>().localScale = new Vector3(PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f), PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f),
                                                                              PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f));

        LeftSlide.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ScaleLeft",1.35f);
        Rightslide.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ScaleRight", 1.35f);
        ClockSlide.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ScaleClock", 1.35f);
        AntiClockSlide.GetComponent<Slider>().value = PlayerPrefs.GetFloat("ScaleAntiClock", 1.35f);


        left1.GetComponent<Image>().color = mYCOLOUR;
        right1.GetComponent<Image>().color = mYCOLOUR;
        clock1.GetComponent<Image>().color = mYCOLOUR;
        anticlock1.GetComponent<Image>().color = mYCOLOUR;
        LeftSlide.SetActive(false);
        Rightslide.SetActive(false);
        ClockSlide.SetActive(false);
        AntiClockSlide.SetActive(false);

        //setting the speed to normal
        Sensitivity_of_Platform.value= PlayerPrefs.GetFloat("platformSpeedss",7f);
       SenstivityOfPlatformRotation.value = PlayerPrefs.GetFloat("platformRotation", 90f);
    }
    public void MakeitDefault()
    {
        FindObjectOfType<AudioManager>().Plays("Select");
        //make slider valure default
        LeftSlide.GetComponent<Slider>().value = 1.35f;
        Rightslide.GetComponent<Slider>().value = 1.35f;
        ClockSlide.GetComponent<Slider>().value = 1.35f;
        AntiClockSlide.GetComponent<Slider>().value = 1.35f;
        new Vector3(1.35f, 1.35f, 1.35f);

        //make the scale default
        left1.GetComponent<RectTransform>().localScale = new Vector3(1.35f, 1.35f, 1.35f);
        right1.GetComponent<RectTransform>().localScale = new Vector3(1.35f, 1.35f, 1.35f);
        clock1.GetComponent<RectTransform>().localScale = new Vector3(1.35f, 1.35f, 1.35f);
        anticlock1.GetComponent<RectTransform>().localScale = new Vector3(1.35f, 1.35f, 1.35f);

        //make the position defaultt
        left1.GetComponent<RectTransform>().localPosition = new Vector3( -284f,  -467.02f , 0f);
        //Right
        right1.GetComponent<RectTransform>().localPosition = new Vector3( -80f, -467.02f, 0f);
        //     //Clock Wise 
        clock1.GetComponent<RectTransform>().localPosition = new Vector3( 287.38f, -583f, 0f);
        //ANticlockWise
        anticlock1.GetComponent<RectTransform>().localPosition = new Vector3( 287.38f,  -401.99f, 0f);
        PlayerPrefs.DeleteKey("LeftX");
        PlayerPrefs.DeleteKey("RightX");
        PlayerPrefs.DeleteKey("ClockX");
        PlayerPrefs.DeleteKey("AntiX");
        PlayerPrefs.DeleteKey("ScaleLeft");
        PlayerPrefs.DeleteKey("ScaleRight");
        PlayerPrefs.DeleteKey("ScaleClock");
        PlayerPrefs.DeleteKey("ScaleAntiClock");



    }
    public void makeSlideronSettingdefaut()
    {
        PlayerPrefs.DeleteKey("platformRotation");
        PlayerPrefs.DeleteKey("platformSpeedss");
        Sensitivity_of_Platform.value = 7f;
        SenstivityOfPlatformRotation.value =90f;
        FindObjectOfType<AudioManager>().Plays("Select");
    }
    private void Update()
    {
        //Debug.Log(left1.GetComponent<RectTransform>().localPosition);
        //Debug.Log(PlayerPrefs.GetFloat("LeftX", -284f));
        //print(PlayerPrefs.GetFloat("LeftX"));

        if (dragit)
        {
            //positon the game object as per the user requirement

           // Debug.Log("Buttonpressed");
          if(Input.touchCount>0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 currentUiposition = Camera.main.ScreenToWorldPoint(touch.position);
                  currentUiposition.z = 0f;
                    print(currentUiposition.x+"   "+ currentUiposition.y);
                    left1.GetComponent<RectTransform>().position = currentUiposition;
                    //GameobjectPositionOnScreen = currentUiposition;//so that it stores the value  of the update position and is accesible 
                                                                   //throughtout the script
                    PlayerPrefs.SetFloat("LeftX", left1.GetComponent<RectTransform>().localPosition.x);

                    PlayerPrefs.SetFloat("LeftY", left1.GetComponent<RectTransform>().localPosition.y);
                    PlayerPrefs.SetFloat("LeftZ", 0f);


                }
            }
            
           
            
        }

        if (dragitRight)
        {
            //positon the game object as per the user requirement

            Debug.Log("Buttonpressed");
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 currentUiposition = Camera.main.ScreenToWorldPoint(touch.position);//temp variable to store the position
                    currentUiposition.z = 0f;
                    right1.GetComponent<RectTransform>().position = currentUiposition;
                  //  GameobjectPositionOnScreen = currentUiposition;//so that it stores the value  of the update position and is accesible 
                                                                   //throughtout the script
                    PlayerPrefs.SetFloat("RightX", right1.GetComponent<RectTransform>().localPosition.x);
                    PlayerPrefs.SetFloat("RightY", right1.GetComponent<RectTransform>().localPosition.y);
                    PlayerPrefs.SetFloat("RightZ", 0f);


                }
            }



        }
        if (dragitClock)
        {
            //positon the game object as per the user requirement

            Debug.Log("Buttonpressed");
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 currentUiposition = Camera.main.ScreenToWorldPoint(touch.position);//temp variable to store the position
                    currentUiposition.z = 0f;
                  clock1.GetComponent<RectTransform>().position = currentUiposition;
                   // GameobjectPositionOnScreen = currentUiposition;//so that it stores the value  of the update position and is accesible 
                                                                   //throughtout the script
                    PlayerPrefs.SetFloat("ClockX", clock1.GetComponent<RectTransform>().localPosition.x);
                    PlayerPrefs.SetFloat("ClockY", clock1.GetComponent<RectTransform>().localPosition.y);
                    PlayerPrefs.SetFloat("ClockZ", 0f);


                }
            }



        }
        if (dragitAntiClock)
        {
            //positon the game object as per the user requirement

            Debug.Log("Buttonpressed");
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Vector3 currentUiposition = Camera.main.ScreenToWorldPoint(touch.position);//temp variable to store the position
                    currentUiposition.z = 0f;
                    anticlock1.GetComponent<RectTransform>().position = currentUiposition;
                  //  GameobjectPositionOnScreen = currentUiposition;//so that it stores the value  of the update position and is accesible 
                                                                   //throughtout the script
                    PlayerPrefs.SetFloat("AntiX", anticlock1.GetComponent<RectTransform>().localPosition.x);
                    PlayerPrefs.SetFloat("AntiY", anticlock1.GetComponent<RectTransform>().localPosition.y);
                    PlayerPrefs.SetFloat("AntiZ", 0f);


                }
            }



        }




    }
    public void DragtheGameObject()
    {
        dragit = true;
    }
    public void DontDragtheGameObject()
    {
        dragit = false;
    }
    public void something()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector3 TouchPositionOnscreen = Camera.main.ScreenToWorldPoint(touch.position);
            TouchPositionOnscreen.z = 0;
            Debug.Log("the Touch id" + TouchPositionOnscreen);
          //  touchregister.transform.position = TouchPositionOnscreen;
        }
    }










    //getting input from the buttons
    public void DragtheGameObjectRight()
    {
       dragitRight = true;
    }
    public void DontDragtheGameObjectRight()
    {
        dragitRight = false;
    }
    public void DragtheGameObjectClock()
    {
        dragitClock = true;
    }
    public void DontDragtheGameObjectClock()
    {
        dragitClock = false;
    }
    public void DragtheGameObjectAntiClock()
    {
        dragitAntiClock = true;
    }
    public void DontDragtheGameObjectAntiClock()
    {
        dragitAntiClock = false;
    }



    //setting the sliddr on and off for each button according to the need;

    public void SliderandColourEnableLEft()
    {
        LeftSlide.SetActive(true);
        Rightslide.SetActive(false);
        ClockSlide.SetActive(false);
        AntiClockSlide.SetActive(false);
        left1.GetComponent<Image>().color = Color.white;
        right1.GetComponent<Image>().color = mYCOLOUR;
        clock1.GetComponent<Image>().color = mYCOLOUR;
        anticlock1.GetComponent<Image>().color = mYCOLOUR;


    }
    public void SliderandColourEnableRight()
    {
        LeftSlide.SetActive(false);
        Rightslide.SetActive(true);
        ClockSlide.SetActive(false);
        AntiClockSlide.SetActive(false);
        left1.GetComponent<Image>().color =mYCOLOUR;
        right1.GetComponent<Image>().color = Color.white;
        clock1.GetComponent<Image>().color = mYCOLOUR;
        anticlock1.GetComponent<Image>().color = mYCOLOUR;

    }
    public void SliderandColourEnableClock()
    {
        LeftSlide.SetActive(false);
        Rightslide.SetActive(false);
        ClockSlide.SetActive(true);
        AntiClockSlide.SetActive(false);
        left1.GetComponent<Image>().color = mYCOLOUR;
        right1.GetComponent<Image>().color = mYCOLOUR;
        clock1.GetComponent<Image>().color = Color.white;
        anticlock1.GetComponent<Image>().color = mYCOLOUR;

    }
    public void SliderandColourEnableAnticlock()
    {

        LeftSlide.SetActive(false);
        Rightslide.SetActive(false);
        ClockSlide.SetActive(false);
        AntiClockSlide.SetActive(true);
        left1.GetComponent<Image>().color = mYCOLOUR;
        right1.GetComponent<Image>().color = mYCOLOUR;
        clock1.GetComponent<Image>().color = mYCOLOUR;
        anticlock1.GetComponent<Image>().color = Color.white;

    }
    public void ChangethesizeofLeft(float ScaleSizw)
    {
        left1.GetComponent<RectTransform>().localScale = new Vector3(ScaleSizw, ScaleSizw, ScaleSizw);
        PlayerPrefs.SetFloat("ScaleLeft", ScaleSizw);

    }
    public void ChangethesizeofRight(float ScaleSizwr)
    {
       right1.GetComponent<RectTransform>().localScale = new Vector3(ScaleSizwr, ScaleSizwr, ScaleSizwr);
        PlayerPrefs.SetFloat("ScaleRight", ScaleSizwr);

    }
    public void ChangethesizeofClock(float ScaleSizwc)
    {
       clock1.GetComponent<RectTransform>().localScale = new Vector3(ScaleSizwc, ScaleSizwc, ScaleSizwc);
        PlayerPrefs.SetFloat("ScaleClock", ScaleSizwc);

    }
    public void ChangethesizeofAntiClock(float ScaleSizwa)
    {
        anticlock1.GetComponent<RectTransform>().localScale = new Vector3(ScaleSizwa, ScaleSizwa, ScaleSizwa);
        PlayerPrefs.SetFloat("ScaleAntiClock", ScaleSizwa);

    }
    public void manageSensitivityOfPlatform(float senss)
    {
        PlayerPrefs.SetFloat("platformSpeedss", senss);
    }
    public void manageSensitivityOfPlatformRotaion(float senssro)
    {
        PlayerPrefs.SetFloat("platformRotation", senssro);
    }
}
