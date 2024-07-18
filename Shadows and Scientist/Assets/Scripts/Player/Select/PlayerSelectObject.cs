using ObjectsNamespace;

namespace PlayerNamespace
{
    public class PlayerSelectObject
    {
        private ISelectable _currentSelectable;

        public void Update()
        {
            ISelectable selectable = PlayerRaycast.Instance.RayCast<ISelectable>();

            if (selectable == null) NullSelectable();

            if (selectable == _currentSelectable) return;

            _currentSelectable = selectable;
            _currentSelectable.Select();
        }

        private void NullSelectable()
        {
            if (_currentSelectable == null) return;

            _currentSelectable.Deselect();
            _currentSelectable = null;
        }
    }
}