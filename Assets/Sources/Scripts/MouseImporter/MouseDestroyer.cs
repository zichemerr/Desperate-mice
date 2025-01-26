using MerJame.PlayerSystem;

namespace MerJame.Importer
{
    public class MouseDestroyer
    {
        public bool IsDestroyed { get; private set; }

        public void Destroy(Mouse[] mouses)
        {
            foreach (var mouse in mouses)
            {
                mouse.Destroy();
            }

            IsDestroyed = true;
        }
    }
}