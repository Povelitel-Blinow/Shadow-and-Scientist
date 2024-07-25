using SmallPlayerNamespace;
using WindowNamespace;
using UnityEngine;

namespace CraftNamespace
{
    public class CraftingBlock : MonoBehaviour
    {
        [SerializeField] private CraftBlockWindow _craftWindowPrefab;
        [SerializeField] private CraftBlockAnimator _animation;

        private CraftBlockWindow _window;

        private void Start()
        {
            _window = Instantiate(_craftWindowPrefab);
            _window.Init(_animation);
        }

        public void Interact()
        {
            Debug.Log("Interact " + gameObject.name);
            _window.ShowUp();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerSurrounding player))
            {
                player.RegisterCraftBlock(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerSurrounding player))
            {
                player.UnregisterCraftBlock(this);
            }
        }
    }
}