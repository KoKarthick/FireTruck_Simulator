using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FireTruck_Sim
{
    public class InputTouch : MonoBehaviour
    {

        bool _canTurnLeft;
        bool _canTurnRight;

        public bool CanTurnLeft { get => _canTurnLeft; }
        public bool CanTurnRight { get => _canTurnRight; set => _canTurnRight = value; }

        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0f;
                if (touch.phase == TouchPhase.Stationary)
                {
                    if (touchPos.x > 0)
                    {
                        _canTurnLeft = true;
                        _canTurnRight = false;
                    }
                    else if (touchPos.x < 0)
                    {
                        _canTurnRight = true;
                        _canTurnLeft = false;
                    }                }
                if (touch.phase == TouchPhase.Ended)
                {
                    _canTurnLeft = false;
                    _canTurnRight = false;
                }
            }
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                _canTurnLeft = true;
            }
            else
            {
                _canTurnLeft = false;
            }
            if (Input.GetMouseButton(1))
            {
                _canTurnRight = true;
            }
            else
            {
                _canTurnRight = false;
            }
#endif
        }
    }
}