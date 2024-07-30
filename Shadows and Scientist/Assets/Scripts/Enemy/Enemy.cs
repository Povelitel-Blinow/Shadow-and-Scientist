using UnityEngine;

namespace EnemyNamespace
{
    [RequireComponent(typeof(EnemyLook))]
    [RequireComponent(typeof(EnemyMove))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyLook _look;
        [SerializeField] private EnemyMove _move;
        [SerializeField] private EnemyAnimate _animate;

        private void Update()
        {
            Vector2 pos = _look.TrySawSpotable();

            if(_look.SeeSpotable() == false)
            {
                _animate.SetIsRunning(false);
                return;
            }

            
            _move.MoveTo(pos);

            _animate.SetIsRunning(true);
        }

        private void OnValidate()
        {
            _look ??= GetComponent<EnemyLook>();
            _move ??= GetComponent<EnemyMove>();
        }
    }
}