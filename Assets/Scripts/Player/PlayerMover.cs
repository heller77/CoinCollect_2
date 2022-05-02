using UnityEngine;

namespace CoinCollect2.Player
{
    public class PlayerMover : MonoBehaviour
    {
        private Vector3 moveVector = new Vector3();
        [SerializeField] private float speed = 1.0f;

        private void Update()
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            Move(moveVector * speed, Time.deltaTime);
        }

        public void Move(Vector3 diff, float deltatime)
        {
            this.transform.position += diff * deltatime;
        }
    }
}