using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        
        private int _activeSceneIndex;


        private void Start()
        {
            _activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public void ChoseFistLevel()
        {
            SceneManager.LoadScene("Level 1");
            
            _loadingScreen.SetActive(true);
        }
        
        public void ChoseSecondLevel()
        {
            SceneManager.LoadScene("Level 2");
            
            _loadingScreen.SetActive(true);
        }
        
        public void ChoseThirdLevel()
        {
            SceneManager.LoadScene("Level 3");
            
            _loadingScreen.SetActive(true);
        }
        
        public void ChoseFourthLevel()
        {
            SceneManager.LoadScene("Level 4");
            
            _loadingScreen.SetActive(true);
        }
        
        public void ChoseFifthLevel()
        {
            SceneManager.LoadScene("Level 5");
            
            _loadingScreen.SetActive(true);
        }
        
        public void ReloadLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex);
        }
        
        public void LoadNextLevel()
        {
            SceneManager.LoadScene(_activeSceneIndex + 1);
        }
        
        public void BackToStartMenu()
        {
            SceneManager.LoadScene("StartGame");
        }
    }
}