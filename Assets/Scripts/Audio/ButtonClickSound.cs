using UnityEngine;
using Zenject;

namespace Audio
{
    public class ButtonClickSound : MonoBehaviour
    {
        private SoundsList _soundsList;


        [Inject]
        public void Construct(SoundsList soundsList)
        {
            _soundsList = soundsList;
        }

        public void OnClick()
        {
            _soundsList.Click();
        }
    }
}