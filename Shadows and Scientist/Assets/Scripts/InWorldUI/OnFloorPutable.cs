using MaterialNamespace;
using System;
using UnityEngine;
using WorldNamespace;

namespace InWorldUINamespace 
{
    public class OnFloorPutable : InSlotPutable
    {
        [SerializeField] private GameObject _ui;
        [SerializeField] private GameObject _real;

        [SerializeField] private RaycastSortingLayer _placedSortingLayer;

        private bool _isPlaced = false;

        public Action OnPickUpAction;
        public Action OnLayDownAction;

        protected override RaycastSortingLayer GetSortingLayer()
        {
            if( _isPlaced ) return _placedSortingLayer;

            return base.GetSortingLayer();
        }

        protected override void OnLayDown()
        {
            base.OnLayDown();
            OnLayDownAction?.Invoke();

            //It works
            if (transform.parent == WorkPlace.Instance.transform)
            {
                transform.parent = null;
                SetIsUI(false);
            }
        }

        protected override void OnPickUp()
        {
            base.OnPickUp();
            OnPickUpAction?.Invoke();
            SetIsUI(true);
        }

        private void SetIsUI(bool isUI)
        {
            _isPlaced = !isUI;
            _ui.SetActive(isUI);
            _real.SetActive(!isUI);
        }
    }
}