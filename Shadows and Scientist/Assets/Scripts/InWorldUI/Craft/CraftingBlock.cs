using SmallPlayerNamespace;
using WindowNamespace;
using UnityEngine;
using InWorldUINamespace;
using WorldNamespace;

namespace CraftNamespace
{
    [RequireComponent(typeof(OnFloorPutable))]
    public class CraftingBlock : MonoBehaviour
    {
        [SerializeField] private CraftBlockWindow _craftWindowPrefab;
        [SerializeField] private CraftBlockAnimator _animation;
        [SerializeField] private CraftingBlockTrigger _trigger;
        [SerializeField] private OnFloorPutable _floor;

        [Header("Sound")]
        [SerializeField] private SoundManager _soundManager;

        private CraftBlockWindow _window;

        private void Start()
        {
            _trigger.OnInteract += Interact;
            _trigger.OnDeinteract += Deinteract;

            _window = Instantiate(_craftWindowPrefab);
            _window.Init();
            _window.OnWork += SetIsWorking;
            _window.OnLineTimerChange += OnTimerValueChanged;

            _floor.OnPickUpAction += OnPickUp;
            _floor.OnLayDownAction += OnLayDown;
        }

        private void Interact()
        {
            _window.ShowUp();
        }

        private void Deinteract()
        {
            _window.Hide();
        }

        private void SetIsWorking(bool isWorking)
        {
            if (isWorking)
                _soundManager.PlaySound();
            else
                _soundManager.StopSound();

            _animation.SetIsWorking(isWorking);
        }

        private void OnPickUp()
        {
            _window.SetCanWork(false);
            _animation.StopAnimating();
        }

        private void OnLayDown()
        {
            _window.SetCanWork(true);
        }

        private void OnTimerValueChanged(float ratio)
        {
            _animation.SetLine(ratio);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out PlayerSurrounding player))
            {
                player.RegisterCraftBlock(_trigger);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerSurrounding player))
            {
                player.UnregisterCraftBlock(_trigger);
            }
        }

        private void OnDisable()
        {
            _trigger.OnInteract -= Interact;
            _trigger.OnDeinteract -= Deinteract;

            _window.OnWork -= SetIsWorking;
            _window.OnLineTimerChange -= OnTimerValueChanged;
            _floor.OnPickUpAction -= OnPickUp;
            _floor.OnLayDownAction -= OnLayDown;
        }

        private void OnValidate()
        {
            _floor ??= GetComponent<OnFloorPutable>();
        }
    }
}