using System;
using CoinCollect2.Items.Coins;
using UnityEngine;

namespace CoinCollect2.GameLoops
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private CoinGenerator _coinGenerator;
        
        //ゲーム時間（デフォルト60s）
        [SerializeField]
        private float gameTime=60.0f;
        [SerializeField]
        private bool isPlayingNow = false;

        private float spentTime = 0.0f;

        public void setIsPlayingNow(bool isPlayingNow)
        {
            this.isPlayingNow = isPlayingNow;
        }
        private void Update()
        {
            

            //ゲーム中なら
            if (isPlayingNow)
            {
                spentTime += Time.deltaTime;
                if ( spentTime > gameTime)
                {
                    isPlayingNow = false;
                    Debug.Log("ゲーム終了！");
                }
                CallCoinGenerate();
                
            }
        }

        private void CallCoinGenerate()
        {
            _coinGenerator.Call(Time.deltaTime);
        }
    }
}