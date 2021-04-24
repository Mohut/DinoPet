using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void BackToMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
