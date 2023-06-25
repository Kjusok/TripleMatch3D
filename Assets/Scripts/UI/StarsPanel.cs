using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class StarsPanel: MonoBehaviour
    {
        private const float TimeTakeThreeStars = 150;
        private const float TimeTakeTwoStars = 120;
        private const float TimeTakeOneStar = 60;
        
        [SerializeField] private Image _starOne;
        [SerializeField] private Image _starTwo;
        [SerializeField] private Image _starThree;

        private Timer _timer;
        
        
        [Inject]
        public void Construct(Timer timer)
        {
            _timer = timer;
        }

        private void Update()
        {
           CheckTime();
        }

        private void CheckTime()
        {
            if (_timer.CurrentTime > TimeTakeThreeStars)
            {
                _starOne.enabled = true;
                _starTwo.enabled = true;
                _starThree.enabled = true;
            }
            if (_timer.CurrentTime > TimeTakeTwoStars)
            {
                _starOne.enabled = true;
                _starTwo.enabled = true;
            }
            if (_timer.CurrentTime > TimeTakeOneStar)
            {
                _starOne.enabled = true;;
            }
        }
    }
}