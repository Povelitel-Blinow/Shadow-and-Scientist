using UnityEngine;

namespace WindowNamespace
{
    public class CloseWindowButton : WindowButton
    {
        [SerializeField] private CraftBlockWindow _window;

        public override void Click()
        {
            Debug.Log("Close");
            _window.Hide();
        }
    }
}
