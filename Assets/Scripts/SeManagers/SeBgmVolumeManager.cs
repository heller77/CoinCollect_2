using System;
using UnityEngine;

namespace CoinCollect2.SeManagers
{
    public class SeBgmVolumeManager : MonoBehaviour
    {
        public float seVolume = 0.1f;
        public float bgmVolume = 0.1f;
        
        private string seVolumeSaveName = "sevolume";
        private string bgmVolumeSaveName = "bgmVolume";
        [SerializeField] private AudioSource seAudioSource;
        
        private void Awake()
        {
            this.seVolume = PlayerPrefs.GetFloat(seVolumeSaveName,0.05f);
            this.bgmVolume = PlayerPrefs.GetFloat(bgmVolumeSaveName, 0.05f);
        }

        public void SetSeVolume(float volume)
        {
            this.seVolume = volume;
            PlayerPrefs.SetFloat(seVolumeSaveName, volume);
            PlayerPrefs.Save();
            seAudioSource.volume = this.seVolume;
        }

        public float GetSeVolume()
        {
            return seVolume;
        }

        public void SetBgmVolume(float volume)
        {
            this.bgmVolume = volume;
            PlayerPrefs.SetFloat(bgmVolumeSaveName, volume);
            PlayerPrefs.Save();
        }
    }
}