using UnityEngine;

namespace Audio
{
    public class StartMenuSoundTrack : MonoBehaviour
    {
        [SerializeField] private AudioSource _soundtrack;

        private void Start()
        {
            _soundtrack.Play();
        }
    }
}