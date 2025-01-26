using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.EventSystem
{
    public class LosingGame : MonoBehaviour
    {
        [SerializeField] private FinishAnimation _animation;
        [SerializeField] private float _delay;

        public void Lose()
        {
            StartCoroutine(LoseRoutine());
        }
        
        private IEnumerator LoseRoutine()
        {
            yield return new WaitForSeconds(_delay);
            yield return _animation.Play("Defeat", Color.black, Color.red);
            SceneManager.LoadScene(0);
        }
    }
}