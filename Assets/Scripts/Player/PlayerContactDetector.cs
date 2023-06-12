using System;
using CoinCollect2.Items;
using CoinCollect2.Items.Coins;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class PlayerContactDetector : MonoBehaviour
    {
        private CoinCollector _coinCollector;
        [SerializeField] private PlayerMover _playerMover;

        public void SetCoinCollector(CoinCollector coinCollector)
        {
            this._coinCollector = coinCollector;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ITouchable getObject))
            {
                getObject.Touch(this);
                // Debug.Log("検出器 「何かに触れた！」");
            }
        }

        public void GetCoin(Coin coin)
        {
            _coinCollector.SetCoin(coin);
        }

        public void SpeedUp(Vector3 dushVector,float speed,float time)
        {
            _playerMover.Dush(dushVector,speed,time);
        }
    }
}