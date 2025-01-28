using MerJame.Importer;
using MerJame.PlayerSystem;
using UnityEngine;
using MerJame.LevelSystem;
using TMPro;
using MerJame.SoundsSystem;
using System;

namespace MerJame.FinishDoor
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private TMP_Text _carpet;
        [SerializeField] private SoundSource _soundSource;

        private Level _level;
        private MouseDestroyer _mouseDestroyer;
        private bool _MouseIsAlived = false;

        public void Init(Level level, MouseDestroyer mouseDestroyer)
        {
            _level = level;
            _mouseDestroyer = mouseDestroyer;
            mouseDestroyer.AllDestroyed += OnAllDestroyed;
        }

        private void OnDisable()
        {
            _mouseDestroyer.AllDestroyed -= OnAllDestroyed;
        }

        private void OnAllDestroyed()
        {
            _sprite.color = Color.black;
            _carpet.text = "Wellcome";
            _MouseIsAlived = true;
            _soundSource.Play();
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