using DG.Tweening;
using UnityEngine;

namespace InWorldUINamespace
{
    public class MoveableDecorator : MonoBehaviour, IMoveable
    {
        [SerializeField] private Moveable _subject;
        [SerializeField] private RaycastSortingLayer _sortingLayer;
        
        public void LayDown()
        {
            _subject.LayDown();
        }

        public void Move(Vector3 position)
        {
            _subject.Move(position);
            transform.position = new Vector3(transform.position.x, transform.position.y, -(int)_sortingLayer);
        }

        public void PickUp(Vector3 position)
        {
            _subject.PickUp(position);
        }
    }
}