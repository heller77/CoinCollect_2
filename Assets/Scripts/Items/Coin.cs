using UnityEngine;
using UnityTemplateProjects.Player;

namespace UnityTemplateProjects.Items
{
    public class Coin : MonoBehaviour,ITouchable
    {
        [SerializeField]
        private CoinType _type;
        public void Touch()
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