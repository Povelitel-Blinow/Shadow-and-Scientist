using CursorNamespace;
using ObjectsNamespace;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerInteract : MonoBehaviour
    {
        private PlayerMoveObject _move;
        private PlayerSelectObject _select;

        public void Init()
        {
            _move = new PlayerMoveObject();
            _select = new PlayerSelectObject();
        }

        public void UpdateInteract()
        {
            //Debug.Log(PlayerRaycast.Instance.RayCast<Moveable>()?.gameObject.name);

            _select.Update();
            _move.Update();

            SetCursor();
        }

        private void SetCursor()
        {
            if (PlayerRaycast.Instance.RayCast<Moveable>() != null)
            {
                CursorUI.Instance.SetCursor(CursorType.CanInteract);
                return;
            }

            CursorUI.Instance.SetCursor(CursorType.NoInteraction);
        }

        public void Interact()
        {
            _select.ForceSelect();
            _move.TryMove();
        }
        
        public void StopInteracting()
        {
            _move.StopMoving();
            _select.StopSelecting();
        } 
    }
}