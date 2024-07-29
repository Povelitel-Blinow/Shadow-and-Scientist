using CursorNamespace;
using InWorldUINamespace;
using UnityEngine;

namespace PlayerNamespace
{
    public class PlayerInteract : MonoBehaviour
    {
        private PlayerMoveObject _move;
        private PlayerSelectObject _select;
        private PlayerClick _click;
        private PlayerTip _tip;

        public void Init()
        {
            _move = new PlayerMoveObject();
            _select = new PlayerSelectObject();
            _click = new PlayerClick();
            _tip = new PlayerTip();
        }

        public void UpdateInteract()
        {
            //Debug.Log(PlayerRaycast.Instance.RayCast<Moveable>()?.gameObject.name);

            _select.Update();
            _move.Update();
            _tip.TryTip();

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
            _click.TryClick();
            _move.TryMove();
        }
        
        public void StopInteracting()
        {
            _move.StopMoving();
        } 
    }
}