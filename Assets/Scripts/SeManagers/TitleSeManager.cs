using UnityEngine;

namespace CoinCollect2.SeManagers
{
    public class TitleSeManager : MonoBehaviour
    {
        [SerializeField] private AudioClip startButtonSe;
        [SerializeField] private AudioSource _audioSource;
        

        public void PlaySeStartButton()
        {
            _audioSource.PlayOneShot(startButtonSe);
        }
        
    }
}