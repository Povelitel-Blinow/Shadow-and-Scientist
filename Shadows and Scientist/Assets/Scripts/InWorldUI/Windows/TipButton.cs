using UnityEngine;

namespace WindowNamespace
{
    public class TipButton : SelectableButton
    {
        [SerializeField] private TipWindow _windowPrefab;

        private TipWindow _window;

        private void Start()
        {
            transform.localPosition += transform.forward * -0.2f;
            _window = Instantiate(_windowPrefab, Vector3.zero, Quaternion.identity);
            _window.Hide();
        }

        public void Hide()
        {
            _window.Hide();
        }

        protected override void OnClick()
        {
            _window.ChangeState();
        }
    }
}