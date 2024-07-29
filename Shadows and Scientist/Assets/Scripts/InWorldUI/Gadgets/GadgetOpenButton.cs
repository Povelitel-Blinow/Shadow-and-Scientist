using UnityEngine;
using InWorldUINamespace;

namespace GadgetNamespace
{
    public class GadgetOpenButton : SlidingButton
    {
        [SerializeField] private GadgetWindow _window;
        protected override void OnClick()
        {
            bool isOpen = _window.IsActive;
            if(isOpen == false)
                _window.ShowUp();
            else
                _window.Hide();
        }
    }
}