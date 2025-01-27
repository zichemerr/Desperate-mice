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
            yield return _animation.Play("The mouse is saved.", Color.black, Color.white, 2);
            yield return _animation.Play("Do you like my game?", Color.black, Color.white);
            _animation.Play("Thanks for playing my game.", Color.black, Color.white);
        }

        private IEnumerator LoseRoutine()
        {
            yield return new WaitForSeconds(_delay);
            _soundSource.Play();
            yield return _animation.Play("Defeat", Color.black, Color.red);
            SceneManager.LoadScene(0);
        }
    }
}