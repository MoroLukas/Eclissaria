using UnityEngine;
using UnityEngine.InputSystem;


public class Pausemenu : MonoBehaviour
{

    public GameObject container;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.P].wasPressedThisFrame) 
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void resumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void mainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main_menu");
    }

}
