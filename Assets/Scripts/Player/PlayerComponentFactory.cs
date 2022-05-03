using System;
using CoinCollect2.GameLoops;
using CoinCollect2.InGameUI;
using CoinCollect2.Result;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class PlayerComponentFactory : MonoBehaviour
    {
        [SerializeField] private PlayerContactDetector _detector;
        private CoinCollector _coinCollector;
        private ScoreCalucurator scoreCalucurator;
        [SerializeField] private GameLoop _gameLoop;
        [SerializeField] private PlayerMover _playerMover;

        public PlayerMover GetPlayerMover()
        {
            return this._playerMover;
        }

        private void Awake()
        {
            this.scoreCalucurator = new ScoreCalucurator();
            _coinCollector = new CoinCollector(scoreCalucurator);
            _detector.SetCoinCollector(_coinCollector);
        }

        private void Start()
        {
            _gameLoop.SetScoreCalucurator(this.scoreCalucurator);
            _gameLoop.SetCoinCollector(this._coinCollector);
        }
    }
}