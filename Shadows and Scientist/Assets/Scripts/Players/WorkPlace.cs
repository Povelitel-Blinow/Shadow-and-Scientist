using MaterialNamespace;
using System.Collections.Generic;
using UnityEngine;

namespace WorldNamespace
{
    public class WorkPlace : MonoBehaviour
    {
        private List<InSlotPutable> _inSlotPutables = new List<InSlotPutable>();

        public static WorkPlace Instance { get; private set; }

        private bool _inBuilding = true;

        public void Init()
        {
            Instance = this;
        }

        public void RegisterInSlotPutable(InSlotPutable inSlot)
        {
            if(_inSlotPutables.Contains(inSlot)) return;

            _inSlotPutables.Add(inSlot);
        }

        public void DeregisterInSLotPutable(InSlotPutable inSlot)
        {
            if(_inSlotPutables.Contains(inSlot) == false) return;

            _inSlotPutables.Remove(inSlot);
        }

        public void Attach(Transform parent)
        {
            transform.parent = parent;
            transform.localPosition = Vector3.zero;
        }

        public void OnBuildingLeave()
        {
            _inBuilding = false;
            //I know that sorting by transform.parent is bot the best way
            //But I don't have much time

            foreach(InSlotPutable inSlot in _inSlotPutables)
            {
                if (inSlot.transform.parent == transform)
                {
                    inSlot.transform.parent = null;
                    inSlot.Hide();
                }
            }
        }

        public void OnBuildingEnter()
        {
            _inBuilding = true;
            foreach(InSlotPutable inSlot in _inSlotPutables)
            {
                inSlot.Show();
            }
        }

        public Transform GetParentTransformForMoveable()
        {
            if(_inBuilding)
                return transform;

            return null;
        }
    }
}