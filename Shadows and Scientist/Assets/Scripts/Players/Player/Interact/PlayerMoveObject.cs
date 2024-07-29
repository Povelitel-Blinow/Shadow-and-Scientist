using InWorldUINamespace;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerMoveObject
    {
        public IMoveable CurrentMoving { get; private set; } = null;

        public void Update()
        {
            if(CurrentMoving == null) return;

            CurrentMoving.Move(PlayerInput.Instance.GetMouseLocalPos());
        }

        public void TryMove()
        {
            IMoveable moveable = PlayerRaycast.Instance.RayCast<IMoveable>();

            if (moveable == null)
            {
                NullMoveable();
                return;
            }

            if (moveable == CurrentMoving) return;
                
            NullMoveable();

            CurrentMoving = moveable;
            moveable.PickUp(PlayerInput.Instance.GetMouseLocalPos());
        }

        private void NullMoveable()
        {
            if (CurrentMoving == null) return;

            CurrentMoving.LayDown();
            CurrentMoving = null;
        }

        public void StopMoving()
        {
            NullMoveable();
        }
    }
}