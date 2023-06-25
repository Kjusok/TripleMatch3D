using Gameplay;
using Gameplay.Goals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private CompleteMenu _completeMenu;
        [SerializeField] private FailedMenu _failedMenu;
        [SerializeField] private PauseMenu _pauseMenu;

        private GoalsHolder _goalsHolder;
        private IFailedLevel _failedLevel;

        private int _activeSceneIndex;

        
        [Inject]
        public void Construct(GoalsHolder goalsHolder, IFailedLevel failedLevel)
        {
            _goalsHolder = goalsHolder;
            _failedLevel = failedLevel;
        }
        
        private void Start()
        {
            _activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            _goalsHolder.TaskCompleted += _completeMenu.Open;
            _failedLevel.TaskFailed += _failedMenu.Open;
        }

        private void OnDestroy()
        {
            _goalsHolder.TaskCompleted -= _completeMenu.Open;
            _failedLevel.TaskFailed -= _failedMenu.Open;
        }
        
        public void SettingsOn()
        {
            _pauseMenu.Open();
        }
        
        public void SettingsOff()
        {
            _pauseMenu.Close();
        }

        public void ExitLevel()
        {
            _pauseMenu.BackToStartMenu();
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex);
        }
        
        public void LoadNextLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex + 1);
        }
    }
}