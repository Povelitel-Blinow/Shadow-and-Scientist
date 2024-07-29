using UnityEngine;

namespace SmallPlayerNamespace
{
    [RequireComponent(typeof(PlayerAnimate))]
    [RequireComponent(typeof(PlayerMove))]
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private PlayerAnimate _playerAnimate;
        [SerializeField] private PlayerMove _playerMove;

        [SerializeField] private PlayerVisualBody _playerVisualBody;

        public void Move(Vector2 input)
        {
            bool isMoving = (input.magnitude != 0);

            _playerAnimate.SetIsWalking(isMoving);
            _playerMove.Move(input);

            _playerVisualBody.ChangeDirection(input);
        }

        private void OnValidate()
        {
            _playerAnimate ??= GetComponent<PlayerAnimate>();
            _playerMove ??= GetComponent<PlayerMove>();
        }
    }
}