using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsBehaviour : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGameAR()
    {
        Application.Quit();
    }
}
