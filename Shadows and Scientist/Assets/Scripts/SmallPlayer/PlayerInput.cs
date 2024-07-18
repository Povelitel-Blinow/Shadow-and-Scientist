using UnityEngine;

namespace SmallPlayerNamespace
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";


        public Vector2 GetMoveInput()
        {
            Vector2 input = Vector2.zero;

            input.x = Input.GetAxisRaw(Horizontal);
            input.y = Input.GetAxisRaw(Vertical);

            return input;
        }
    }
}