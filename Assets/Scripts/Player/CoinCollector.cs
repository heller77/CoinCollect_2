using System;
using System.Collections.Generic;
using CoinCollect2.Items.Coins;
using CoinCollect2.Result;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class CoinCollector
    {
        private Dictionary<CoinType, int> collectCoinNumber;
        private ScoreCalucurator _scoreCalucurator;

        public CoinCollector(ScoreCalucurator scoreCalucurator)
        {
            collectCoinNumber = new Dictionary<CoinType, int>();
            foreach (CoinType cointype in Enum.GetValues(typeof(CoinType)))
            {
                collectCoinNumber.Add(cointype,0);
            }
            _scoreCalucurator = scoreCalucurator;
        }

        public ScoreCalucurator getScoreCalucurator()
        {
            return this._scoreCalucurator;
        }
        public void SetCoin(Coin coin)
        {
            collectCoinNumber[coin.GetCoinType()] += 1;
            _scoreCalucurator.addScoreByCoin(coin);
        }

        public Dictionary<CoinType,int> GetCollectCoinDictionary()
        {
            return this.collectCoinNumber;
        }
    }
}