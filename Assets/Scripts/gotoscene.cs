using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoscene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
