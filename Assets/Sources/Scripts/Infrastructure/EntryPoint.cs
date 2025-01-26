using UnityEngine;
using MerJame.InputSystem;
using MerJame.PlayerSystem;
using MerJame.Spawning;
using MerJame.Importer;
using MerJame.FinishDoor;
using MerJame.Ghost;
using MerJame.Obstacle;
using MerJame.EventSystem;
using MerJame.LevelSystem;

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
        [SerializeField] private Level _level;

        private PlayerInput _playerInput;

        private void Start()
        {
            _level.Init();
            _playerMovement.Init(_mouseSpawnerController, _ghost);
            _box.Disable();
            _mouseSpawnerController.Init(_box);
            _player.Init(_playerMovement, _losingGame, _mouseSpawnerController);
            _mouseImporter.Init();
            _exitDoor.Init(_level, _mouseImporter.MouseDestroyer, _box);
            _playerInput = new PlayerInput(_playerMovement);
        }

        private void Update()
        {
            _playerInput?.Update();
        }
    }
}