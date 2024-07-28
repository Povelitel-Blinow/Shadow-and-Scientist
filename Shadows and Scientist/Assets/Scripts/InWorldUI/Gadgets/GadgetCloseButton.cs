using InWorldUINamespace;
using UnityEngine;

namespace GadgetNamespace
{
    public class GadgetCloseButton : SlidingButton
    {
        [SerializeField] private GadgetWindow _window;

        protected override void OnClick()
        {
            _window.Hide();
        }
    }
}