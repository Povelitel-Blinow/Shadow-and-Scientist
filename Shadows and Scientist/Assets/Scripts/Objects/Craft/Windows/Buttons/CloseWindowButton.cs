using UnityEngine;

namespace WindowNamespace
{
    public class CloseWindowButton : WindowButton
    {
        [SerializeField] private CraftBlockWindow _window;

        public override void OnClick()
        {
            _window.Hide();
        }
    }
}
