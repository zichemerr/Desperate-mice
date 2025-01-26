using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.LevelSystem
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private int _maxScenes;

        private int _indexCurrentScene;
        private int _indexNextScene => _indexCurrentScene + 1;

        public void Init()
        {
            _indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        }

        public void NextLevel()
        {
            if (_indexCurrentScene == _maxScenes)
            {
                SceneManager.LoadScene(_maxScenes);
                return;
            }

            SceneManager.LoadScene(_indexNextScene);
        }
    }
}