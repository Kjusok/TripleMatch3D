using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartSceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

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
    }
}