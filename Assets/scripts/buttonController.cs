
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
}

