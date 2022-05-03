using System;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class PlayerComponentFactory : MonoBehaviour
    {
        [SerializeField] private PlayerContactDetector _detector;
        private CoinCollector _coinCollector;
        
        private void Awake()
        {
            _coinCollector = new CoinCollector();
            _detector.SetCoinCollector(_coinCollector);
            
        }
    }
}