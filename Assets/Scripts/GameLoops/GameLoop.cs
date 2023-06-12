using System;
using CoinCollect2.InGameUI;
using CoinCollect2.Items.Coins;
using CoinCollect2.Player;
using CoinCollect2.Result;
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
        private float limitedTime;
        [SerializeField] private InGameView _inGameView;
        [SerializeField] private PlayerComponentFactory _playerComponentFactory;
        private ScoreCalucurator _scoreCalucurator;
        private CoinCollector _coinCollector;

        [SerializeField] private ResultView _resultView;
        [SerializeField] private ResultManager _resultManager;
        
        
        public void setIsPlayingNow(bool isPlayingNow)
        {
            this.isPlayingNow = isPlayingNow;
        }

        private void Start()
        {
            limitedTime = gameTime;
        }

        private void Update()
        {
            //ゲーム中なら
            if (isPlayingNow)
            {
                spentTime += Time.deltaTime;
                limitedTime =gameTime -spentTime;
                if ( spentTime > gameTime)
                {
                    isPlayingNow = false;
                    FinishGame();
                }
                CallCoinGenerate();
                UpdateInGameUI();
            }
        }

        public void SetScoreCalucurator(ScoreCalucurator scoreCalucurator)
        {
            this._scoreCalucurator = scoreCalucurator;
        }

        public void SetCoinCollector(CoinCollector coinCollector)
        {
            this._coinCollector = coinCollector;
        }
        private void CallCoinGenerate()
        {
            _coinGenerator.Call(Time.deltaTime);
        }

        public void UpdateInGameUI()
        {
            _inGameView.UpdateGameTime(limitedTime);
            _inGameView.UpdateScore(this._scoreCalucurator.GetScore());
            //コインのディクショナリ
            var coinDictionary = _coinCollector.GetCollectCoinDictionary();
            _inGameView.UpdateGoldCoinText(coinDictionary[CoinType.Gold]);
            _inGameView.UpdateSilverText(coinDictionary[CoinType.Silver]);
            _inGameView.UpdateCopperText(coinDictionary[CoinType.Copper]);
            _inGameView.UpdateMagnification(_scoreCalucurator.GetMagnification());
        }

        /// <summary>
        /// ゲーム終了
        /// </summary>
        public void FinishGame()
        {
            var playerMover = _playerComponentFactory.GetPlayerMover();
            playerMover.SetSpeed(0.0f);
            // _resultView.ShowResul(_coinCollector,_scoreCalucurator);
            _resultManager.startResult(_coinCollector,_scoreCalucurator,"css");
        }
    }
}