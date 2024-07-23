using SmallPlayerNamespace;
using WindowNamespace;
using UnityEngine;

namespace CraftNamespace
{
    public abstract class CraftingBlock : MonoBehaviour
    {
        [SerializeField] private CraftBlockWindow _craftWindow;

        public void Interact()
        {
            Debug.Log("Interact " + gameObject.name);
            _craftWindow.ShowUp();
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