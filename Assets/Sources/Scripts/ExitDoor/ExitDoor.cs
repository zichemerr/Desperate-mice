using MerJame.Importer;
using MerJame.PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.FinishDoor
{
    public class ExitDoor : MonoBehaviour
    {
        private ImporterController _importer;
        private bool _importerIsAssebled = false;

        public void Init(ImporterController mouseImporter)
        {
            _importer = mouseImporter;
            _importer.Assembled += OnAssembled;
        }

        private void OnDisable()
        {
            _importer.Assembled -= OnAssembled;
        }

        private void OnAssembled()
        {
            _importerIsAssebled = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_importerIsAssebled == false)
                return;

            if (collision.gameObject.GetComponent<Mouse>())
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}