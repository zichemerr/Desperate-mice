using MerJame.InputSystem;
using MerJame.PlayerSystem;
using MerJame.Spawning;
using MerJame.Importer;
using MerJame.FinishDoor;
using MerJame.Ghost;
using MerJame.Obstacle;
using MerJame.EventSystem;
using UnityEngine;

namespace MerJame.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Player _player;
        [SerializeField] private MouseSpawnerController _mouseSpawnerController;
        [SerializeField] private ExitDoor _exitDoor;
        [SerializeField] private MouseGhost _ghost;
        [SerializeField] private ImporterController _mouseImporter;
        [SerializeField] private Box _box;
        [SerializeField] private LosingGame _losingGame;

        private PlayerInput _playerInput;

        private void Start()
        {
            _playerMovement.Init(_mouseSpawnerController, _ghost);
            _box.Disable();
            _mouseSpawnerController.Init(_box);
            _mouseImporter.Init();
            _player.Init(_mouseImporter, _playerMovement, _losingGame);
            _exitDoor.Init(_mouseImporter, _box);
            _playerInput = new PlayerInput(_playerMovement);
        }

        private void Update()
        {
            _playerInput?.Update();
        }
    }
}