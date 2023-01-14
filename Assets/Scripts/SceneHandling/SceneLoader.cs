using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneHandling
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneSO _scenesToLoad;
    
        private void Awake()
        {
            foreach (var sceneName in _scenesToLoad.SceneList)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }
    }
}
