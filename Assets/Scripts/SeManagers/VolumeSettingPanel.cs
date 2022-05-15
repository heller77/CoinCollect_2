using System;
using CoinCollect2.GameLoops;
using UnityEngine;
using UnityEngine.UI;

namespace CoinCollect2.SeManagers
{
    /// <summary>
    /// volume弄る所
    /// </summary>
    public class VolumeSettingPanel : MonoBehaviour
    {
        [SerializeField] private SeBgmVolumeManager _seBgmVolumeManager;
        [SerializeField] private Slider seSlider;
        [SerializeField] private GameObject sesettingPaneel;

        private void Start()
        {
            var sevolume = _seBgmVolumeManager.GetSeVolume();
            seSlider.value = sevolume;
        }

        public void seValueChanged()
        {
            _seBgmVolumeManager.SetSeVolume(seSlider.value);
        }

        public void ShowSettingPanel()
        {
            sesettingPaneel.SetActive(true);
        }

        public void HideSettingPanel()
        {
            sesettingPaneel.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ShowSettingPanel();
            }
        }
    }
}