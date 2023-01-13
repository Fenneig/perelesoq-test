using SceneHandling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneSO _scenesToLoad;
    
    private void Start()
    {
        foreach (var sceneName in _scenesToLoad.SceneList)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }
}
