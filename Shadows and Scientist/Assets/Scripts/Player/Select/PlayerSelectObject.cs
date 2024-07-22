using ObjectsNamespace;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerSelectObject
    {
        private ISelectable _currentSelectable;

        public void ForceSelect()
        {
            ISelectable selectable = PlayerRaycast.Instance.RayCast<ISelectable>();

            if (selectable == null) return;

            NullSelectable();
            _currentSelectable = selectable;
            _currentSelectable.Select();
        }

        public void Update()
        {
            ISelectable selectable = PlayerRaycast.Instance.RayCast<ISelectable>();

            if (selectable == null) NullSelectable();

            if (selectable == _currentSelectable) return;

            NullSelectable();
            _currentSelectable = selectable;
            _currentSelectable.Select();
        }

        private void NullSelectable()
        {
            if (_currentSelectable == null) return;

            _currentSelectable.Deselect();
            _currentSelectable = null;
        }

        public void StopSelecting()
        {
            if(_currentSelectable == null) return;

            _currentSelectable.Deselect();
        }
    }
}