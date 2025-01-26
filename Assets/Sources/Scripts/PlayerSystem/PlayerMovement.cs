using MerJame.Ghost;
using MerJame.Spawning;
using System.Collections.Generic;
using UnityEngine;

namespace MerJame.PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private List<Mouse> _movements;

        private MouseSpawnerController _mouseSpawner;
        private MouseGhost _mouseGhost;

        public int MouseCount => _movements.Count;

        public void Init(MouseSpawnerController mouseSpawner, MouseGhost mouseGhost)
        {
            _mouseSpawner = mouseSpawner;
            _mouseGhost = mouseGhost;
            _mouseSpawner.Spawned += OnSpawned;
        }

        private void OnDisable()
        {
            _mouseSpawner.Spawned -= OnSpawned;

            foreach (var movement in _movements)
            {
                movement.Destroyed -= OnDestroyed;
            }
        }

        private void OnSpawned(Mouse mouse)
        {
            _movements.Add(mouse);
            mouse.Destroyed += OnDestroyed;
        }

        private void OnDestroyed(Mouse mouse)
        {
            _movements.Remove(mouse);
            _mouseGhost.PlayAniamtion();
            Destroy(mouse.gameObject);
        }

        public void Move(Vector2 cursorPosition)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(cursorPosition);

            foreach (Mouse movement in _movements)
            {
                movement.Move(position);
            }
        }
    }
}