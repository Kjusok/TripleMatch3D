using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class StarsPanel: MonoBehaviour
    {
        private const float TimeTakeThreeStars = 160;
        private const float TimeTakeTwoStars = 120;
        private const float TimeTakeOneStar = 100;
        
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
            _starOne.enabled = _timer.CurrentTime > TimeTakeOneStar;
            _starTwo.enabled = _timer.CurrentTime > TimeTakeTwoStars;
            _starThree.enabled = _timer.CurrentTime > TimeTakeThreeStars;
        }
    }
}