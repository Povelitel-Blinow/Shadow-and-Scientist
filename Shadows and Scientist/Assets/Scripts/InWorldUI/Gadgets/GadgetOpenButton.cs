using UnityEngine;
using InWorldUINamespace;

namespace GadgetNamespace
{
    public class GadgetOpenButton : SlidingButton
    {
        [SerializeField] private GadgetWindow _window;

        protected override void OnClick()
        {
            _window.ShowUp();
        }
    }
}