using UnityEngine.SceneManagement;
using UnityEngine;

public class GoHomeThisTime : MonoBehaviour
{
    public void AlohaHome()
    {
        SceneManager.LoadScene("start");
    }
}
