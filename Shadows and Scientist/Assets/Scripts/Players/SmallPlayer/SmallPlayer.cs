using DG.Tweening;
using SmallWorldNamespace;
using UnityEngine;
using WorldNamespace;

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

        private bool _isActive = true;

        public static SmallPlayer Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        private void Update()
        {
            if (_isActive == false) return;

            _energySeeker.UpdateSeeker();
            _body.Move(_input.GetMoveInput());

            if(_input.GetIsInteract())
                _surroundings.TryInteract();
        }

        public void GoThroughtWall(GateWay way)
        {
            _isActive = false;
            transform.DOComplete();

            //I LOVE DOTween :3
            transform.DOMove(way.InPos, way.ToInPosTime).OnComplete(() =>
            {
                transform.DOMove(way.OutPos, way.ToOutPosTime).OnComplete(() =>
                {
                    _isActive = true;
                });
            });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private void OnValidate()
        {
            _input ??= GetComponent<PlayerInput>();
            _body ??= GetComponent<PlayerBody>();
        }
    }
}