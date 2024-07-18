using PlayerNamespace;
using UnityEngine;

namespace CursorNamespace 
{
    public class CursorUI : MonoBehaviour
    {
        [SerializeField] private Sprite _noInteraction;
        [SerializeField] private Sprite _canInteract;

        [SerializeField] private SpriteRenderer _cursor;

        public static CursorUI Instance { get; private set; }

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
                Cursor.visible = false;
                SetCursor(CursorType.NoInteraction);
                return;
            }
            Destroy(gameObject);
        }

        public void SetCursor(CursorType cursorType)
        {
            switch (cursorType)
            {
                case CursorType.CanInteract:
                    _cursor.sprite = _canInteract;
                    break;

                default:
                    _cursor.sprite = _noInteraction;
                    break;
            }
        }

        private void Update()
        {
            Cursor.visible = false;
            transform.position = PlayerInput.Instance.GetMousePos();
        } 
    }

    public enum CursorType
    {
        NoInteraction,
        CanInteract,
    }
}