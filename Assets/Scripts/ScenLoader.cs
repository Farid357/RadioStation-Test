using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class ScenLoader : MonoBehaviour
{

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Antenna.IsConnect = false;
        Wire.IsConnect = false;
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
