using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("TestLukas");
    }
    public void QuiteGame()
    {
        Application.Quit();
    }

}
