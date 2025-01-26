using MerJame.InputSystem;
using MerJame.PlayerSystem;
using MerJame.Spawning;
using MerJame.Importer;
using MerJame.FinishDoor;
using MerJame.Ghost;
using UnityEngine;

namespace MerJame.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private MouseSpawnerController _mouseSpawnerController;
        [SerializeField] private ExitDoor _exitDoor;
        [SerializeField] private MouseGhost _ghost;
        [SerializeField] private ImporterController _mouseImporter;

        private PlayerInput _playerInput;

        private void Start()
        {
            _playerMovement.Init(_mouseSpawnerController, _ghost);
            _mouseSpawnerController.Init();
            _mouseImporter.Init();
            _exitDoor.Init(_mouseImporter);
            _playerInput = new PlayerInput(_playerMovement);
        }

        private void Update()
        {
            _playerInput?.Update();
        }
    }
}