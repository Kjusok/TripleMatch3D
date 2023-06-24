using Gameplay.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CompleteMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        
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

        public void SafeTime(string time)
        {
            _timerText.text = time;
        }
    }
}