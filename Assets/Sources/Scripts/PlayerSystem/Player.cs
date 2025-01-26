using UnityEngine;
using MerJame.Importer;
using MerJame.EventSystem;

namespace MerJame.PlayerSystem
{
    public class Player : MonoBehaviour
    {
        private ImporterController _importerController;
        private PlayerMovement _playerMovement;
        private LosingGame _losingGame;

        public void Init(ImporterController importerController, PlayerMovement playerMovement, LosingGame losingGame)
        {
            _importerController = importerController;
            _playerMovement = playerMovement;
            _losingGame = losingGame;
            _importerController.Assembled += OnAssembled;
        }

        private void OnDisable()
        {
            _importerController.Assembled -= OnAssembled;
        }

        private void OnAssembled()
        {
            if (_playerMovement.MouseCount > 0)
                return;

            _losingGame.Lose();
        }
    }
}