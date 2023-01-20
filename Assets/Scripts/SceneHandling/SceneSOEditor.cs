#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SceneHandling
{
    public partial class SceneSO : ISerializationCallbackReceiver
    {
        [SerializeField] private List<SceneAsset> SceneAssets;

        public void OnBeforeSerialize()
        {
            if (SceneList == null) return;
        
            SceneList.Clear();
            foreach (var sceneAsset in SceneAssets)
            {
                if (sceneAsset == null) continue;
                SceneList.Add(sceneAsset.name);
            }
        }

        public void OnAfterDeserialize(){}
    }
}
#endif