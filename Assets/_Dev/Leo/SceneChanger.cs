using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string SceneToChange;
    private Scene currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneToChange);
    }
    public void ChangeSceneWithCode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RealoadScene()
    {
        SceneManager.LoadScene(currentScene.name);
    }
}