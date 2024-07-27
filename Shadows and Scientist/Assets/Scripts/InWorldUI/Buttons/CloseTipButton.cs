using UnityEngine;
using WindowNamespace;

namespace InWorldUINamespace
{
    public class CloseTipButton : MonoBehaviour, IClickable
    {
        [SerializeField] private TipWindow _tipWindow;
        public void Click()
        {
            _tipWindow.Hide();
        }
    }
}