using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickShop()
    {
        SceneManager.LoadScene(2);
    }

    public void OnClickConfig()
    {
        SceneManager.LoadScene(3);
    }
}
