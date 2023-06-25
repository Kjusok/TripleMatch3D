using Gameplay.Services;
using UnityEngine;
using Zenject;

namespace UI
{
    public class FailedMenu : MonoBehaviour
    {
        private IPause _pauseManager;

        [Inject]
        public void Construct(IPause pause)
        {
            _pauseManager = pause;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _pauseManager.Paused = true;
        }
    }
}