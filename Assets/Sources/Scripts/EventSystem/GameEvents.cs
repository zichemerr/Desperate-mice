using MerJame.InputSystem;
using MerJame.SoundsSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.EventSystem
{
    public class GameEvents : MonoBehaviour
    {
        [SerializeField] private FinishAnimation _animation;
        [SerializeField] private SoundSource _soundSource;
        [SerializeField] private AudioClip _winClip;
        [SerializeField] private float _delay;

        private PlayerInput _playerInput;

        public void Init(PlayerInput playerInput)
        {
            _playerInput = playerInput;
        }

        public void Lose()
        {
            StartCoroutine(LoseRoutine());
        }

        public void Win()
        {
            StartCoroutine(WinRoutine());
        }

        private IEnumerator WinRoutine()
        {
            _soundSource.Play(_winClip);
            _playerInput.Disable();
            yield return _animation.Play("The mouse is saved.", Color.black, Color.white, 3);
            yield return _animation.Play("Do you like my game?", Color.black, Color.white, 3);
            _animation.Play("Thanks for playing my game.", Color.black, Color.white);
        }

        private IEnumerator LoseRoutine()
        {
            yield return new WaitForSeconds(_delay);
            _soundSource.Play(0.8f);
            yield return _animation.Play("Defeat", Color.black, Color.red);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}