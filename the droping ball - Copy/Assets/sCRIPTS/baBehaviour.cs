using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baBehaviour : MonoBehaviour
{
    public ParticleSystem DeathBaby,winBaby;
    public GameObject PauseButtonOnScreen,placeHolder;
    //  public GameObject DeathScreens;
    private Rigidbody2D Rb;
    private void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        PauseButtonOnScreen.SetActive(true);
       // DeathScreens.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(Rb.velocity);
        Vector2 veloRb = Rb.velocity;
        veloRb.y = Mathf.Clamp(veloRb.y, -9f, 20f);
        Rb.velocity = veloRb;
        if(Rb.velocity.y<-9.5f)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, -8f);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            if (GameStartManager.Normal)
            {
                transform.position = new Vector3(4.28f, -5.38f, 89.5f);
                PauseButtonOnScreen.SetActive(false);
                DeathBaby.Play();
                FindObjectOfType<AudioManager>().Plays("Death");
                //it shuld open a small window whwere it says restart and playagain;
                FindObjectOfType<GAMEMANAGER>().BallLavaTouch();
                // FindObjectOfType<BlockBehaviour>().initialBlockNo();
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //  DeathScreens.SetActive(true);

            }
            else if (GameStartManager.Hardcore)
            {

                PauseButtonOnScreen.SetActive(false);
                DeathBaby.Play();                               
                FindObjectOfType<AudioManager>().Plays("Death");
                FindObjectOfType<GAMEMANAGER>().BallLavaTouch();

                transform.position = new Vector3(4.28f, -5.38f, 89.5f);
                //   FindObjectOfType<GAMEMANAGER>().levelrestart();

            }

            PauseButtonOnScreen.SetActive(false);
        }

        if (collision.gameObject.tag == "Goals")
        {
            if (GameStartManager.Normal)
            {
                winBaby.Play();
                PauseButtonOnScreen.SetActive(false);
                //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // GetComponent<GAMEMANAGER>().levelchanger();
                gameObject.transform.position = placeHolder.transform.position;
                FindObjectOfType<AudioManager>().Plays("Win");
                //  FindObjectOfType<GAMEMANAGER>().Newlevel();
                FindObjectOfType<GAMEMANAGER>().NewNoSetIfWin();
                FindObjectOfType<GAMEMANAGER>().winscreeen.SetActive(true);
            }else if(GameStartManager.Hardcore)
            {
                PauseButtonOnScreen.SetActive(false);
                winBaby.Play();
                //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // GetComponent<GAMEMANAGER>().levelchanger();
                gameObject.transform.position = placeHolder.transform.position;
                FindObjectOfType<AudioManager>().Plays("Win");
                 FindObjectOfType<GAMEMANAGER>().Newlevel();
                
            }
        }  
        if(collision.gameObject.tag=="Player")
        {
            FindObjectOfType<AudioManager>().Plays("Jump");
        }
    }

   
   

}
