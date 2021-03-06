using System.Collections.Generic;
using UnityEngine;

namespace CoinCollect2.Items.Coins
{
    public class CoinGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _coinGameObject;

        // [SerializeField] private float _interval=3.0f;
        [SerializeField]
        private List<Coin> _coinList = new List<Coin>();
        [SerializeField] private Vector2 leftDownPoint = new Vector2();
        [SerializeField] private Vector2 rightUpPoint = new Vector2();
        [SerializeField] private float y = 1.0f;
        void Generate(CoinType type)
        {
            var tmpCoinGameObject = Instantiate(_coinGameObject);
            tmpCoinGameObject.transform.position = new Vector3(Random.Range(leftDownPoint.x,rightUpPoint.x), y, Random.Range(leftDownPoint.y,rightUpPoint.y));
            var tmpCoin = tmpCoinGameObject.GetComponent<Coin>();
            _coinList.Add(tmpCoin);
            tmpCoin.SetCoinType(type);
        }

        public void GenerateCoins(int goldNum,int silverNum,int copperNum)
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

        private bool completedFirstGenerate = false;
        //コイン生成のスパン（間隔）
        [SerializeField]private float span = 10.0f;
        //ゲーム開始からの経過時間
        private float timeToNextGenerate = 0.0f;
        /// <summary>
        /// ゲームループ側から呼ばれる
        /// </summary>
        /// <param name="deltatime"></param>
        public void Call(float deltatime)
        {
            timeToNextGenerate += deltatime;
            if (!completedFirstGenerate)
            {
                GenerateCoins(10, 10, 10);
                completedFirstGenerate = true;
            }
            if (timeToNextGenerate >= span)
            {
                timeToNextGenerate -= span;
                GenerateCoins(10,10,10);
            }
        }
    }
}