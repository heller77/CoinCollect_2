using CoinCollect2.Player;
using UnityEngine;

namespace CoinCollect2.Items.Coins
{
    public class Coin : MonoBehaviour,ITouchable
    {
        [SerializeField]
        private CoinType _type;
        public void Touch(PlayerContactDetector detector)
        {
            Debug.Log("コイン取得した");
        }

        public void SetCoinType(CoinType type)
        {
            this._type = type;
        }

        public CoinType GetCoinType(CoinType type)
        {
            return type;
        }
    }
}