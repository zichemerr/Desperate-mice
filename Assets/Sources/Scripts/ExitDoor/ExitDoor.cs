using MerJame.Importer;
using MerJame.PlayerSystem;
using MerJame.Obstacle;
using UnityEngine;
using UnityEngine.SceneManagement;
using MerJame.LevelSystem;

namespace MerJame.FinishDoor
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;

        private Level _level;
        private MouseDestroyer _mouseDestroyer;
        private Box _box;
        private bool _MouseIsAlived = false;

        public void Init(Level level, MouseDestroyer mouseDestroyer, Box box)
        {
            _level = level;
            _mouseDestroyer = mouseDestroyer;
            _box = box;
            mouseDestroyer.AllDestroyed += OnAllDestroyed;
        }

        private void OnDisable()
        {
            _mouseDestroyer.AllDestroyed -= OnAllDestroyed;
        }

        private void OnAllDestroyed()
        {
            _sprite.color = Color.black;
            _MouseIsAlived = true;
            _box.Disable();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_MouseIsAlived == false)
                return;

            if (collision.gameObject.GetComponent<Mouse>())
            {
                _level.NextLevel();
            }
        }
    }
}