using MaterialNamespace;
using System.Collections.Generic;
using UnityEngine;

namespace WorldNamespace
{
    public class WorkPlace : MonoBehaviour
    {
        private List<InSlotPutable> _inSlotPutables = new List<InSlotPutable>();

        public static WorkPlace Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }

        public void RegisterInSlotPutable(InSlotPutable inSlot)
        {
            if(_inSlotPutables.Contains(inSlot)) return;

            _inSlotPutables.Add(inSlot);
        }

        public void DeregisterInSLotPutable(InSlotPutable inSlotPutable)
        {

        }

        public void Attch(Transform parent)
        {
            transform.parent = parent;
            transform.localPosition = Vector3.zero;
        }

        public void Deattach()
        {
            transform.parent = null;
        }
    }
}