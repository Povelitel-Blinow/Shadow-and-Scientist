using InWorldUINamespace;
using PlayerNamespace;
using UnityEngine;

namespace CursorNamespace 
{
    public class CursorUI : MonoBehaviour
    {
        [SerializeField] private Sprite _noInteraction;
        [SerializeField] private Sprite _canInteract;

        [SerializeField] private SpriteRenderer _cursor;

        [SerializeField] private TipText _tipText;

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

        public void TipObject(TipableObjectNames name)
        {
            _tipText.SetTip(name);
        }

        public void StopTipping()
        {
            _tipText.Hide();
        }

        private void Update()
        {
            Cursor.visible = false;
            transform.position = PlayerInput.Instance.GetMouseGlobalPos();
        } 
    }

    public enum CursorType
    {
        NoInteraction,
        CanInteract,
    }
}