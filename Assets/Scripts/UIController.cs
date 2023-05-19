using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private void Awake()
    {
        SnakeMovement.OnPlayerDeath += SnakeMovement_OnPlayerDeath;
    }

    private void SnakeMovement_OnPlayerDeath()
    {
        GetComponent<Canvas>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}