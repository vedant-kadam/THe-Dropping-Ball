using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
   public  int RandomNumber;
    public Sprite[] numbers;
    public SpriteRenderer curr;
    public GameObject blockss;
    public ParticleSystem BlockBreak;
    public int lastBlockno=10,firstBlock=1;
    private void Start()
    {
        gameObject.SetActive(true);
        initialBlockNo();
    }

    public void initialBlockNo()
    {
        //initially it willtake a random no
        RandomNumber = Random.Range(firstBlock,lastBlockno);
        //the random no which is selected the sprit e of same number is selected

        curr.sprite = numbers[RandomNumber - 1];
    }

    public void setNewSprit(int spriteno)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "balls")
        {
            OnBallHitBlock();

        }
    }
    public void OnBallHitBlock()
    {
        RandomNumber = RandomNumber - 1;
        if (RandomNumber <= 0)
        {
            BlockBreak.Play();
             Destroy(blockss);
           // gameObject.SetActive(false);
        }
        else
        {
           // gameObject.SetActive(true);
            curr.sprite = numbers[RandomNumber - 1];
            setNewSprit(RandomNumber);
        }

    }
    

}
