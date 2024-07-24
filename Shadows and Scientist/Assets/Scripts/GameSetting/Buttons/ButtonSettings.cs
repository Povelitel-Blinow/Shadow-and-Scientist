using UnityEngine;

namespace GameDesign
{
    [CreateAssetMenu(menuName = "Game Design/ButtonSettings")]
    public class ButtonSettings : ScriptableObject
    {
        public float ClickScaleRatio;
        public float ClickTime;
    }
}