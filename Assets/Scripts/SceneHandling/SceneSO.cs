using System.Collections.Generic;
using UnityEngine;

namespace SceneHandling
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "ScriptableObject/SceneData")]
    public partial class SceneSO : ScriptableObject
    {
        [HideInInspector] public List<string> SceneList;
    }
}