using System;
using System.Collections.Generic;
using CoinCollect2.Items.Coins;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class CoinCollector
    {
        private Dictionary<CoinType, int> collectCoinNumber ;

        public CoinCollector()
        {
            collectCoinNumber = new Dictionary<CoinType, int>();
            foreach (CoinType cointype in Enum.GetValues(typeof(CoinType)))
            {
                collectCoinNumber.Add(cointype,0);
            }
        }

        public void SetCoin(Coin coin)
        {
            collectCoinNumber[coin.GetCoinType()] += 1;
        }

        public Dictionary<CoinType,int> GetCollectCoinDictionary()
        {
            return this.collectCoinNumber;
        }
    }
}