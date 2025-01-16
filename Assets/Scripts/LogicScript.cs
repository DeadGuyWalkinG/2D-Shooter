using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    [SerializeField]
    private int scorepoints = 0;
    [SerializeField]
    private Text Score;
    [SerializeField]
    private Text gameScore;
    [SerializeField]
    private GameObject gameOverScreen;

    void Start()
    {
        gameScore.text = "";
    }

    void Update()
    {
        
    }

    [ContextMenu("Increase Score")]
    public void increaseScore()
    { 
        scorepoints++;
        Score.text = scorepoints.ToString();
        Debug.Log("Score increased");
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
        gameScore.text="Score: "+scorepoints.ToString();
        gameOverScreen.SetActive(true);
    }

    public void retryButton()
    {
        Debug.Log("Game Reset");
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    public void exitMenuButton()
    {
        Debug.Log("Game Exited to Main Menu");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }



}
