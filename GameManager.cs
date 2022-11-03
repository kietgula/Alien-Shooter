using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }    
    
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void GameWin()
    {
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
