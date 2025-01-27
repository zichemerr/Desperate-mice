using MerJame.EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.LevelSystem
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxScenes;

        private GameEvents _gameEvents;
        private int _indexCurrentScene;
        private int _indexNextScene => _indexCurrentScene + 1;

        public void Init(GameEvents gameEvents)
        {
            _gameEvents = gameEvents;
            _indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        }

        public void NextLevel()
        {
            if (_indexCurrentScene == _maxScenes)
            {
                _gameEvents.Win();
                return;
            }

            SceneManager.LoadScene(_indexNextScene);
        }
    }
}