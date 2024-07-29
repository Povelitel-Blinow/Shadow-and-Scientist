using CraftNamespace;
using SmallPlayerNamespace;
using UnityEngine;

namespace WorldNamespace
{
    public abstract class GateWay : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _inPos;
        [SerializeField] private Transform _outPos;

        [SerializeField] private float _toInPosTime;
        [SerializeField] private float _toOutPosTime;

        [Header("Parent Building")]
        [SerializeField] protected Building _building;

        public Vector3 InPos => _inPos.position;
        public Vector3 OutPos => _outPos.position;
        public float ToInPosTime => _toInPosTime;
        public float ToOutPosTime => _toOutPosTime;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void Interact()
        {
            PlayerManager.Instance.GoThroughtWall(this);
            OnInteract();
        }

        protected virtual void OnInteract() { }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerSurrounding player))
            {
                player.RegisterCraftBlock(this);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerSurrounding player))
            {
                player.UnregisterCraftBlock(this);
            }
        }
    }
}