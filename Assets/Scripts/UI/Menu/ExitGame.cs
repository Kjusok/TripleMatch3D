using Audio;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ExitGame : MonoBehaviour
    {
        private SoundsList _soundsList;

        
        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }
        
        public void QuitGame()
        {
            _soundsList.Click();
            Application.Quit();
        }
    }
}