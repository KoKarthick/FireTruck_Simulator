using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FireTruck_Sim
{
    public class Truck : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float turnRate;

        float turnSmoothvelocity;
        InputTouch inputTouch;
        Vector2 dir;

        public float Speed { get => speed; set => speed = value; }
        private void Awake()
        {
            inputTouch = FindObjectOfType<InputTouch>().GetComponent<InputTouch>();
        }

        void Update()
        {
            if (inputTouch.CanTurnLeft)
            {
                dir.x =- 1f;
            }
            if (inputTouch.CanTurnRight)
            {
                dir.x =1f;
            }
            if (!inputTouch.CanTurnLeft&& !inputTouch.CanTurnRight)
            {
                dir.x = 0;
            }
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg+ this.transform.eulerAngles.y;
            var angleToRotate = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, angle, ref turnSmoothvelocity, turnRate);
            this.transform.rotation = Quaternion.Euler(0f, angleToRotate, 0f);
            this.transform.Translate(this.transform.forward * speed * Time.deltaTime,Space.World);

        }
       
    }
}
