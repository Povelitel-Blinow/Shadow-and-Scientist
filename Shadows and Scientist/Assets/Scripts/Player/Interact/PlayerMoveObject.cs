using InWorldUINamespace;

namespace PlayerNamespace
{
    public class PlayerMoveObject
    {
        public Moveable CurrentMoving { get; private set; } = null;

        public void Update()
        {
            if(CurrentMoving == null) return;

            CurrentMoving.Move(PlayerInput.Instance.GetMousePos());
        }

        public void TryMove()
        {
            Moveable moveable = PlayerRaycast.Instance.RayCast<Moveable>();

            if (moveable == null)
            {
                NullMoveable();
                return;
            }

            if (moveable == CurrentMoving) return;
                
            NullMoveable();

            CurrentMoving = moveable;
            moveable.PickUp(PlayerInput.Instance.GetMousePos());
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