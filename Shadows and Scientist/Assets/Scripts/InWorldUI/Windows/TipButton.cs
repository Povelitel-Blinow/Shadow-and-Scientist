using UnityEngine;

namespace WindowNamespace
{
    public class TipButton : SelectableButton
    {
        [SerializeField] private TipWindow _window;

        protected override void OnClick()
        {
            _window.ShowUp();
        }
    }
}