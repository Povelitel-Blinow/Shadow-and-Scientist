using UnityEngine;
using WorldNamespace;

namespace WindowNamespace
{
    public class TipWindow : MonoBehaviour
    {
        private bool _isActive = false;

        public void Init()
        {
            gameObject.SetActive(true);

            transform.parent = WorkPlace.Instance.transform;
            transform.localPosition = Vector3.zero;

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