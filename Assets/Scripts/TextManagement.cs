using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManagement : MonoBehaviour
{
    public GameObject TextObj;
    public float SecondsToWait;
    public float SecondsToDisplay;
    private Animator animator;
    public string goToScene = "";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManageText());
        animator = GetComponent<Animator>();
    }

    public IEnumerator ManageText()
    {
        yield return new WaitForSeconds(SecondsToWait);
        animator.SetTrigger("AnimationText");
        yield return new WaitForSeconds(SecondsToDisplay);
        animator.SetTrigger("DisparitionText");
        if (!string.IsNullOrEmpty(goToScene))
        {
            SceneManager.LoadScene(goToScene);
        }
    }

}
