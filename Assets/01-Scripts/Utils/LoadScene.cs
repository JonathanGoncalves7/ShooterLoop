using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OnCLickLoadScene(int sceneIndex)
    {
        StartCoroutine(this.CRLoadScene(sceneIndex));
    }

    IEnumerator CRLoadScene(int sceneIndex)
    {
        Time.timeScale = 1f;

        AudioManager.s_instance.PlayButtonClick();

        yield return new WaitForSeconds(AudioManager.s_instance.GetButtonClickClip().length);

        SceneManager.LoadScene(sceneIndex);
    }

    public void OnCLickLoadAditiveScene(int sceneIndex)
    {
        StartCoroutine(this.CRLoadAditiveScene(sceneIndex));
    }

    IEnumerator CRLoadAditiveScene(int sceneIndex)
    {
        AudioManager.s_instance.PlayButtonClick();

        if (Time.timeScale > 0)
            yield return new WaitForSeconds(AudioManager.s_instance.GetButtonClickClip().length);

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        StartCoroutine(this.CRUnloadScene(3));
    }

    IEnumerator CRUnloadScene(int index)
    {
        AudioManager.s_instance.PlayButtonClick();

        if (Time.timeScale > 0)
            yield return new WaitForSeconds(AudioManager.s_instance.GetButtonClickClip().length);

        SceneManager.UnloadSceneAsync(index);
    }
}
