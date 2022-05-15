using System;
using CoinCollect2.Items;
using CoinCollect2.Player;
using UnityEngine;

namespace CoinCollect2.Stage
{
    public class SpeedupFloor : MonoBehaviour,ITouchable
    {
        [SerializeField] private Vector3 speedUpVector;
        [SerializeField] private float speed;
        [SerializeField] private float time;

        private void Start()
        {
            speedUpVector = transform.right;
        }

        public void Touch(PlayerContactDetector detector)
        {
            detector.SpeedUp(speedUpVector,speed,time);
        }
    }
}