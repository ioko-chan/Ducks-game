using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;
using Gameplay;
using static Gameplay.CharacterControllers;

namespace Manager
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private EventListener _eventPressControllButton;

        [SerializeField]
        private CharacterData _characterData;

        [SerializeField]
        private GameObject _leftBorder;

        [SerializeField]
        private GameObject _rightBorder;

        [SerializeField]
        private CharacterController _cameraController;

        private void OnEnable()
        {
            _eventPressControllButton.OnEventHappened += UpdatePosition;
        }

        private void OnDisable()
        {
            _eventPressControllButton.OnEventHappened -= UpdatePosition;
        }

        private void UpdatePosition()
        {
            if (!isBorder())
            {
                MoveCamera();
            }
            else if(isBorderLeft() && (Math.Abs(_characterData.Position.x - _leftBorder.transform.position.x) > 12) && (_characterData.Direction == CharacterControllers.Direction.Right))
            {
                MoveCamera();
            }
            else if (isBorderRight() && ((Math.Abs(_characterData.Position.x - _rightBorder.transform.position.x) > 12)) && (_characterData.Direction == CharacterControllers.Direction.Left))
            {
                MoveCamera();
            }
        }

        private bool isBorder()
        {
            if(isBorderRight() )
            {
                return true;
            }
            else if( isBorderLeft())
            {
                return true;
            }
            return false;
        }

        private bool isBorderRight()
        {
            if(_camera.transform.position.x + 10 < _rightBorder.transform.position.x)
            {
                return false;
            }
            return true;
        }

        private bool isBorderLeft()
        {
            if (_camera.transform.position.x - 12 > _leftBorder.transform.position.x )
            {
                return false;
            }
            return true;
        }

        private void MoveCamera()
        {
            float moveVectorCamera = 0;

            switch (_characterData.Direction)
            {
                case Direction.Left:
                    {
                        moveVectorCamera= -_characterData.Speed;
                        break;
                    }
                case Direction.Right:
                    {
                        moveVectorCamera= _characterData.Speed;
                        break;
                    }
            }
            _cameraController.Move(new Vector3(moveVectorCamera * Time.deltaTime,0,0));
        }
    }
}