﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CoinCollect2.Player
{
    public class PlayerMover : MonoBehaviour
    {
        private Vector3 moveVector = new Vector3();
        [SerializeField] private float speed = 1.0f;

        private Rigidbody _rigidbody;

        // [SerializeField] private float dushTime=1.0f;
        // [SerializeField] private float dushAddSpedd=3.0f;
        [SerializeField] private float dushSpeed;
        [SerializeField] private float dushIntervalTime = 1.0f;
        [SerializeField] private bool isDushAble = true;
        [SerializeField] private float dushTime=0.4f;

        private void Start()
        {
            this._rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Input.GetAxis("Vertical");
            moveVector = moveVector.normalized;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Vector3 shiftMove = moveVector * speed;
                // Debug.Log(shiftMove.magnitude);
                // _rigidbody.AddForce(moveVector*speed,ForceMode.Impulse);
                // speedupInAnyTime(dushTime,dushAddSpedd);
                if (isDushAble)
                    Dush(moveVector,speed,dushTime);
            }
        }

        private void FixedUpdate()
        {
            Move(moveVector * speed, Time.deltaTime);
        }

        public void Move(Vector3 diff, float deltatime)
        {
            // Debug.Log("move " + diff);
            // this.transform.position += diff * deltatime;
            _rigidbody.velocity = diff * deltatime;
            // _rigidbody.MovePosition(this.transform.position+diff*deltatime);
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        
        private async UniTask speedupInAnyTime(float limitedTime, float addSpeed)
        {
            Debug.Log("speed up");
            //一定時間スピードをあげて
            this.speed += addSpeed;
            await UniTask.Delay(TimeSpan.FromSeconds(limitedTime));
            this.speed -= addSpeed;
            Debug.Log("speed down");
        }

        private bool forCancel = false;
        public async UniTask Dush(Vector3 dushVector,float dushSpeed,float time)
        {
            float elapsedTime = 0.0f;
            forCancel = true;
            await UniTask.DelayFrame(1);
            forCancel = false;
            while (true)
            {
                if (elapsedTime > time||forCancel)
                {
                    // Debug.Log("加速終了");
                    break;
                }
                _rigidbody.AddForce(dushVector * (dushSpeed * 2), ForceMode.Acceleration);
                await UniTask.DelayFrame(1);
                elapsedTime += Time.deltaTime;

            }

            DushIntervalCalucurateStart();
        }

        private async UniTask DushIntervalCalucurateStart()
        {
            this.isDushAble = false;
            await UniTask.Delay(TimeSpan.FromSeconds(this.dushIntervalTime));
            this.isDushAble = true;
        }
       
    }
}