using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverPanel;
    
    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
       
    }
    
}
