using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            if (GameStartManager.Normal)
            {
                FindObjectOfType<baBehaviour>().DeathBaby.Play();
                FindObjectOfType<AudioManager>().Plays("Death");
                //it shuld open a small window whwere it says restart and playagain;
                FindObjectOfType<GAMEMANAGER>().BallLavaTouch();
                // FindObjectOfType<BlockBehaviour>().initialBlockNo();
                // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //  DeathScreens.SetActive(true);

            }
            else if (GameStartManager.Hardcore)
            {
                FindObjectOfType<baBehaviour>().DeathBaby.Play();
                FindObjectOfType<AudioManager>().Plays("Death");
                FindObjectOfType<GAMEMANAGER>().levelrestart();
            }


        }
    }
}
