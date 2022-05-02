using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items.Coins
{
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinGameObject;

        [SerializeField] private float _interval=3.0f;

        private List<Coin> _coinList = new List<Coin>();
        void Generate(CoinType type)
        {
            var tmpCoin = Instantiate(_coinGameObject).GetComponent<Coin>();
            _coinList.Add(tmpCoin);
            tmpCoin.SetCoinType(type);
        }

        void GenerateCoins(int goldNum,int silverNum,int copperNum)
        {
            for (int i = 0; i < goldNum; i++)
            {
                this.Generate(CoinType.Gold);
            }

            for (int i = 0; i < silverNum; i++)
            {
                this.Generate(CoinType.Silver);
            }

            for (int i = 0; i < copperNum; i++)
            {
                this.Generate(CoinType.Copper);
            }
        }
        
    }
}