using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void startGameButton()
    {
        Debug.Log("Game Scene loaded");
        SceneManager.LoadScene("GameScene");
    }

    public void exitGameButton()
    {
        Debug.Log("Bye!");
        Application.Quit();
    }
}
