using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsBehaviour : MonoBehaviour
{
    //change scene AR
    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //close apk AR
    public void ExitGameAR()
    {
        Application.Quit();
    }
}
