using CraftNamespace;
using EnemyNamespace;
using SmallPlayerNamespace;
using System.Collections;
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

        [Header("Sound")]
        [SerializeField] private SoundManager _interactsoundManager;
        [SerializeField] private SoundManager _breakInsoundManager1;
        [SerializeField] private SoundManager _breakInsoundManager2;

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
            _interactsoundManager?.PlaySound();
            OnInteract();
        }

        protected virtual void OnInteract() { }

        public void BreakIn(Enemy enemy)
        {
            StartCoroutine(BreakingIn(enemy));
        }

        private IEnumerator BreakingIn(Enemy enemy)
        {
            _breakInsoundManager1?.PlaySound();

            float time = Random.Range(20, 50);
            time = time / 10;
            yield return new WaitForSeconds(time);

            _breakInsoundManager2?.PlaySound();

            OnBreakIn(enemy);
        }

        protected virtual void OnBreakIn(Enemy enemy) { }

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