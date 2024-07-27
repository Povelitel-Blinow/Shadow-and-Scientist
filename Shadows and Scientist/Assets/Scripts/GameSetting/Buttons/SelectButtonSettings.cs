using UnityEngine;

namespace GameDesign
{
    [CreateAssetMenu(menuName = "Game Design/SelectButtonSettings")]
    public class SelectButtonSettings : ScriptableObject
    {
        public float SelectScaleRatio;
        public float SelectScaleTime;
    }
}