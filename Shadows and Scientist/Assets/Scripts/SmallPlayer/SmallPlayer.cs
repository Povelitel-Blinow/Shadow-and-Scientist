using UnityEngine;

namespace SmallPlayerNamespace
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerBody))]
    public class SmallPlayer : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerBody _body;

        public void Init()
        {
            Debug.Log("Inited");
        }

        private void Update()
        {
            _body.Move(_input.GetMoveInput());
        }

        private void OnValidate()
        {
            _input ??= GetComponent<PlayerInput>();
            _body ??= GetComponent<PlayerBody>();
        }
    }
}