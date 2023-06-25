using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

        public void ChoseFistLevel()
        {
            SceneManager.LoadScene("BaseLevel");
            
            _loadingScreen.SetActive(true);
        }
    }
}