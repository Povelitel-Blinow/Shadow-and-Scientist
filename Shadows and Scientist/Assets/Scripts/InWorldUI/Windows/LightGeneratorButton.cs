using DG.Tweening;
using InWorldUINamespace;
using UnityEngine;
using GameDesign;

namespace WindowNamespace
{
    public class LightGeneratorButton : SelectableButton
    {
        [Header("ShowUp Settings")]
        [SerializeField] private Transform _moveable;
        [SerializeField] private Transform _openPos;
        [SerializeField] private float _openTime;

        [Header("Raycast")]
        [SerializeField] private RaycastSortingLayer _sortingLayer;

        private bool _isOpened = false;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        protected override void OnClick()
        {
            if (_isOpened == false) return;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _isOpened = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, -(int)_sortingLayer); 
            _moveable.DOMove(_openPos.position, _openTime);
        }

        private void OnDestroy()
        {
            _moveable.DOKill();
        }
    }
}