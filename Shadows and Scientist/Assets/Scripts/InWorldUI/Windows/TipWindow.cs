using UnityEngine;

namespace WindowNamespace
{
    public class TipWindow : MonoBehaviour
    {
        private bool _isActive = false;

        public void ShowUp()
        {
            gameObject.SetActive(true);
            _isActive = true;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _isActive = false;
        }

        public void ChangeState()
        {
            _isActive = !_isActive;
            gameObject.SetActive(_isActive);
        }
    }
}