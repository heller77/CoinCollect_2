using UnityEngine;

namespace CoinCollect2.SeManagers
{
    public class InGameSeManager : MonoBehaviour
    {
        [SerializeField] private AudioClip coinSe;
        [SerializeField] private AudioSource _audioSource;
        

        public void PlaySeGetCoin()
        {
            _audioSource.PlayOneShot(coinSe);
        }
    }
}