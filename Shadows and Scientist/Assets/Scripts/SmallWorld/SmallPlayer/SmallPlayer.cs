using SmallWorldNamespace;
using UnityEngine;

namespace SmallPlayerNamespace
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerBody))]
    public class SmallPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerBody _body;
        [SerializeField] private PlayerSurrounding _surroundings;
        [SerializeField] private SmallEnergySeeker _energySeeker;

        public void Init()
        {
        
        }

        private void Update()
        {
            _energySeeker.UpdateSeeker();
            _body.Move(_input.GetMoveInput());

            if(_input.GetIsInteract())
                _surroundings.TryInteract();
        }

        private void OnValidate()
        {
            _input ??= GetComponent<PlayerInput>();
            _body ??= GetComponent<PlayerBody>();
        }
    }
}