using CoinCollect2.Player;
using CoinCollect2.SeManagers;
using UnityEngine;

namespace CoinCollect2.Items.Coins
{
    public class Coin : MonoBehaviour,ITouchable
    {
        [SerializeField]
        private CoinType _type;

        private InGameSeManager _inGameSeManager;

        public void SetInGameSeManager(InGameSeManager semanager)
        {
            this._inGameSeManager = semanager;
        }
        public void Touch(PlayerContactDetector detector)
        {
            detector.GetCoin(this);
            this._inGameSeManager.PlaySeGetCoin();
            Destroy(this.gameObject);
        }

        public void SetCoinType(CoinType type)
        {
            this._type = type;
        }

        public CoinType GetCoinType()
        {
            return this._type;
        }
    }
}