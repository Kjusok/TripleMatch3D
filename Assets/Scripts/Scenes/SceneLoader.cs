using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

        private int _activeSceneIndex;
        private SoundsList _soundsList;

        
        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }

        private void Start()
        {
            _activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void ChoseFistLevel()
        {
            SceneManager.LoadScene("Level 1");

            _loadingScreen.SetActive(true);
            _soundsList.Click();
        }

        public void ChoseSecondLevel()
        {
            SceneManager.LoadScene("Level 2");

            _loadingScreen.SetActive(true);
            _soundsList.Click();
        }

        public void ChoseThirdLevel()
        {
            SceneManager.LoadScene("Level 3");

            _loadingScreen.SetActive(true);
            _soundsList.Click();
        }

        public void ChoseFourthLevel()
        {
            SceneManager.LoadScene("Level 4");

            _loadingScreen.SetActive(true);
            _soundsList.Click();
        }

        public void ChoseFifthLevel()
        {
            SceneManager.LoadScene("Level 5");

            _loadingScreen.SetActive(true);
            _soundsList.Click();
        }

        public void ReloadLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex);
            _soundsList.Click();
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex + 1);
            _soundsList.Click();
        }

        public void BackToStartMenu()
        {
            SceneManager.LoadScene("StartGame");
            _soundsList.Click();
        }
    }
}