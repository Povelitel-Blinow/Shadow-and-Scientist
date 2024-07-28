using UnityEngine;

namespace InWorldUINamespace
{
    public class MoveablMirror : MonoBehaviour, IMoveable
    {
        [SerializeField] private Moveable _subject;
        
        public void LayDown()
        {
            _subject.LayDown();
        }

        public void Move(Vector3 position)
        {
            _subject.Move(position);
        }

        public void PickUp(Vector3 position)
        {
            _subject.PickUp(position);
        }
    }
}