using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Manager
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private EventListener _updatePositionListener;

        [SerializeField]
        private GameObject _leftBorder;

        [SerializeField]
        private GameObject _rightBorder;

        [SerializeField]
        private CharacterController _duck;


        private void OnEnable()
        {
            _updatePositionListener.OnEventHappened += UpdatePosition;
        }

        private void OnDisable()
        {
            _updatePositionListener.OnEventHappened -= UpdatePosition;
        }

        private void UpdatePosition()
        {
            if (!isBorder())
            {
                _camera.transform.position = new Vector3(_duck.transform.position.x, _camera.transform.position.y, _camera.transform.position.z);
            }
            else
            {
                
            }
        }

        private bool isBorder()
        {
            if(_camera.transform.position.x >= _leftBorder.transform.position.x && _camera.transform.position.x <= _rightBorder.transform.position.x)
            {
                return false;
            }
            return true;
        }
    }
}