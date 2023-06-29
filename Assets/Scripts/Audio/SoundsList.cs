using UnityEngine;

namespace Audio
{
    public class SoundsList: MonoBehaviour
    {
        [Header("UI Sounds")]
        [SerializeField] private AudioClip _click;
        [SerializeField] private AudioClip _tapToggle;
        
        [Header("Effect Sounds")]
        [SerializeField] private AudioClip _magnet;
        [SerializeField] private AudioClip _fallingItems;
        
        [Header("Gameplay Sounds")]
        [SerializeField] private AudioClip _takeItem;
        [SerializeField] private AudioClip _vanishingTriple;
        [SerializeField] private AudioClip _vanishingGoal;
        
        [Header("Event Sounds")]
        [SerializeField] private AudioClip _winLevel;
        [SerializeField] private AudioClip _failedLevel;
        
        [Header("AudioSources")]
        [SerializeField] private AudioSource _audioSourceUI;
        [SerializeField] private AudioSource _audioSourceEffects;

        
        public void Click()
        {
            _audioSourceUI.PlayOneShot(_click);
        }
        
        public void TapToggle()
        {
            _audioSourceUI.PlayOneShot(_tapToggle);
        }
        
        public void Magnet()
        {
            _audioSourceEffects.PlayOneShot(_magnet);
        }
        
        public void FallingItems()
        {
            _audioSourceEffects.PlayOneShot(_fallingItems);
        }
        
        public void TakeItem()
        {
            _audioSourceEffects.PlayOneShot(_takeItem);
        }
        
        public void VanishingTriple()
        {
            _audioSourceEffects.PlayOneShot(_vanishingTriple);
        }
        
        public void VanishingGoal()
        {
            _audioSourceEffects.PlayOneShot(_vanishingGoal);
        }
        
        public void WinLevel()
        {
            _audioSourceEffects.PlayOneShot(_winLevel);
        }

        public void FailedLevel()
        {
            _audioSourceEffects.PlayOneShot(_failedLevel);
        }
    }
}