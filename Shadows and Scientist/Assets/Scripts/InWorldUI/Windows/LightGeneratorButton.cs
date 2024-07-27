using DG.Tweening;
using InWorldUINamespace;
using UnityEngine;
using GameDesign;

namespace WindowNamespace
{
    public class LightGeneratorButton : Button, ISelectable
    {
        [Header("Select Settings")]
        [SerializeField] private RedButtonSettings _redButtonsettings;

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

        public void Select()
        {
            transform.DOScale(_redButtonsettings.SelectScaleRatio, _redButtonsettings.SelectScaleTime);
        }

        public void Deselect()
        {
            transform.DOScale(1, _redButtonsettings.SelectScaleTime);
        }

        private void OnDestroy()
        {
            _moveable.DOKill();
            transform.DOKill();
        }
    }
}