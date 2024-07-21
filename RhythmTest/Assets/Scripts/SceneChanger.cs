using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public Animator animator;
    private string sceneToLoad;
    private bool isTransitingScene = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.UpArrow)) {
            fadeToScene("StartScreen");
        }

        if (Input.GetKeyDown(KeyCode.T) && Input.GetKeyDown(KeyCode.UpArrow)) {
            fadeToScene("Tutorial");
        }

        if (Input.GetKeyDown(KeyCode.N) && Input.GetKeyDown(KeyCode.UpArrow)) {
            fadeToScene("SampleScene");
        }
    }

    public void fadeToScene (string sceneName) {
        if (isTransitingScene) {
            // do not transit again if it is already in the middle of transition
            return;
        }
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
        isTransitingScene = true;
    }

    public void onFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
        isTransitingScene = false;
    }

    public void waitAndFadeToScene(string sceneName, float duration) {
        StartCoroutine(PreSceneChangeDelay(sceneName, duration));
    }

    private IEnumerator PreSceneChangeDelay(string sceneName, float duration) {
        yield return new WaitForSeconds(duration);
        fadeToScene(sceneName);
    }
}
