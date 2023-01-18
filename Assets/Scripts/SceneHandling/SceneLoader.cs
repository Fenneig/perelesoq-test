using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneHandling
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneAsset _mainScene;
        [SerializeField] private SceneSO _scenesToLoad;
    
        private void Awake()
        {
            foreach (var sceneName in _scenesToLoad.SceneList)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(_mainScene.name);
        }
    }
}
