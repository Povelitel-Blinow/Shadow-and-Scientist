using UnityEngine;

namespace PlayerNamespace
{
    [RequireComponent(typeof(PlayerInteract))]
    [RequireComponent(typeof(PlayerRaycast))]
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInteract _interact;
        [SerializeField] private PlayerRaycast _raycast;
        [SerializeField] private PlayerInput _input;

        public void Init()
        {
            _input.Init();
            _raycast.Init();
            _interact.Init();
        }

        public void Update()
        {
            if (_input.GetMouseDown())
            {
                _interact.Interact();
            }

            if(_input.GetMouseUp())
            {
                _interact.StopInteracting();
            }

            _interact.UpdateInteract();
        }

        private void OnValidate()
        {
            _interact = GetComponent<PlayerInteract>();
            _raycast = GetComponent<PlayerRaycast>();
            _input = GetComponent<PlayerInput>();
        }
    }
}