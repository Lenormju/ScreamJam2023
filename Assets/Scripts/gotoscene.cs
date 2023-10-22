using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoscene : MonoBehaviour
{
    public void SetPreviousScene(string previousScene)
    {
        GameManager.previous_scene = previousScene;
    }

    private bool _goToPrevious = false;

    public void SetWantToGoToPrevious(bool goToPrevious)
    {
        _goToPrevious = goToPrevious;
    }

    public void LoadScene(string sceneName)
    {
        if(_goToPrevious && GameManager.previous_scene != null){
            sceneName = GameManager.previous_scene;
            GameManager.previous_scene = null;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
