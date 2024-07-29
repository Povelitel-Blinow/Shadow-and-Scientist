using DG.Tweening;
using InWorldUINamespace;
using SlotNamespace;
using UnityEngine;
using WorldNamespace;

namespace MaterialNamespace
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class InSlotPutable : Moveable, IInSlopPutable
    {
        [Header("InSlotPutable params")]
        [SerializeField] private LayerMask _slotLayer;

        private float _raycastDistance = 100;

        private Slot _slot;

        private void Start()
        {
            WorkPlace.Instance.RegisterInSlotPutable(this);
        }

        protected override void OnLayDown()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, _raycastDistance, _slotLayer);

            if(hit.collider == null) return;

            if (hit.collider.TryGetComponent(out Slot slot))
            {
                TryPutInSlot(slot);
            }
        }

        private void TryPutInSlot(Slot parentSlot)
        {
            if (parentSlot.TryPut(this))
            {
                _slot = parentSlot;
                MoveToSlot(_slot);
            }
        }

        private void MoveToSlot(Slot slot)
        {
            transform.position = slot.transform.position + GetSortingOffset();
            transform.parent = slot.transform;
        }

        /// <summary>
        /// This method is used by OutputSlots ONLY
        /// </summary>
        /// <param name="outputSlot"></param>
        public void InitByOutputSlot(Slot outputSlot)
        {
            _slot = outputSlot;
            transform.localScale = Vector3.zero;
            Show();
            MoveToSlot(outputSlot);
        }

        protected override void OnPickUp()
        {
            if(_slot == null) return;

            _slot.PutOut();

            _slot = null;
        }

        public void Show()
        {
            transform.DOComplete();
            transform.DOScale(1, 0.5f).OnComplete(() =>
            {
                gameObject.SetActive(true);
            });
        }

        public void Hide()
        {
            transform.DOComplete();
            transform.DOScale(0, 0.5f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
        //DRY? Nah, never heard of it
        public void Void()
        {
            //Yeah, I know that there is a 0.3s gap
            //in which player can take it out

            transform.DOComplete();
            transform.DOScale(0, 0.3f).OnComplete(() =>
            {
                WorkPlace.Instance.DeregisterInSLotPutable(this);
                gameObject.SetActive(false);
                Destroy(gameObject);
            });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}