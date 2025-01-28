using UnityEngine;
using UnityEngine.SceneManagement;
using MerJame.InputSystem;
using MerJame.PlayerSystem;
using MerJame.Spawning;
using MerJame.Importer;
using MerJame.FinishDoor;
using MerJame.Ghost;
using MerJame.EventSystem;
using MerJame.LevelSystem;
using MerJame.StaringView;
using MerJame.Obstacle;

namespace MerJame.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private Player _player;
        [SerializeField] private MouseSpawnerController _mouseSpawnerController;
        [SerializeField] private ExitDoor _exitDoor;
        [SerializeField] private MouseGhostAnimation _ghost;
        [SerializeField] private ImporterController _mouseImporter;
        [SerializeField] private GameEvents _losingGame;
        [SerializeField] private Level _level;
        [SerializeField] private CatGhost _catGhost;
        [SerializeField] private StartView _startView;
        [SerializeField] private BoxController _boxController;

        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = new PlayerInput(_playerMovement);
            _losingGame.Init(_playerInput);
            _level.Init(_losingGame);
            _playerMovement.Init(_mouseSpawnerController, _ghost);
            _mouseSpawnerController.Init();
            _player.Init(_playerMovement, _losingGame, _mouseSpawnerController);
            _mouseImporter.Init();
            _catGhost?.Init();
            _exitDoor.Init(_level, _mouseImporter.MouseDestroyer);
            _boxController.Init();
            _startView.Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            _playerInput?.Update();
        }
    }
}