using UnityEngine;

namespace UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _viewPanel;

        private float _timer = 0.2f;

        private void Update()
        {
            TurnOffLoadingScreen();
        }

        private void TurnOffLoadingScreen()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }

            if (_timer <= 0)
            {
                Hide();
            }
        }

        private void Hide()
        {
            if (_timer <= 0)
            {
                _viewPanel.SetActive(false);
                enabled = false;
            }
        }
    }
}