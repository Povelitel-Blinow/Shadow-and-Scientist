using UnityEngine;
using WindowNamespace;

namespace InWorldUINamespace
{
    public class CloseWindowButton : SlidingButton
    {
        [SerializeField] private CraftBlockWindow _window;

        protected override void OnClick()
        {
            _window.Hide();
        }
    }
}
