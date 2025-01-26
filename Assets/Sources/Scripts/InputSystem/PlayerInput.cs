using UnityEngine;
using MerJame.PlayerSystem;

namespace MerJame.InputSystem
{
    public class PlayerInput
    {
        private PlayerMovement _playerMovement;

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
            //if (Input.GetMouseButtonDown(0))
            //{
            //    _playerMovement.Move(CursorPosition);
            //    return;
            //}

            if (Input.GetMouseButton(0))
            {
                _playerMovement.Move(CursorPosition);
            }
        }
    }
}