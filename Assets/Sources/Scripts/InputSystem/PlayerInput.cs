using UnityEngine;
using MerJame.PlayerSystem;

namespace MerJame.InputSystem
{
    public class PlayerInput
    {
        private PlayerMovement _playerMovement;
        private bool _isActive = true;

        public PlayerInput(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private Vector2 CursorPosition
        {
            get
            {
                Vector2 position = Input.mousePosition;
                return position;
            }
        }

        public void Update()
        {
            if (_isActive == false)
                return;

            if (Input.GetMouseButton(0))
            {
                _playerMovement.Move(CursorPosition);
            }
        }

        public void Disable()
        {
            _isActive = false;
        }
    }
}