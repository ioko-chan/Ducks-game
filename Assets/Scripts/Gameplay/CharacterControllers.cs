using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;
using System;

namespace Gameplay
{
    public class CharacterControllers : MonoBehaviour
    {
        private CharacterController _characterController;
        public enum CharacterState
        {
            Move,
            Stand,
            Think
        }

        public CharacterState CurrentState;
        public enum Direction
        {
            Left ,
            Right
        }

        public Direction CurrentDirection;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }

        [SerializeField]
        private CharacterData _characterData;

        [SerializeField]
        private Transform _leftBorder;

        [SerializeField]
        private Transform _rightBorder;

        public void Move(Direction direction)
        {
            CurrentDirection = direction;
            _characterData.ChangeDirection(direction);

            CurrentState = CharacterState.Move;
            _characterData.ChangeState(CharacterState.Move);

            _characterData.ChangePosition(transform.position);
            Vector3 moveVector = Vector3.zero;
            switch (direction)
            {
                case Direction.Left:
                    {
                        moveVector.x = -1;
                        break;
                    }
                case Direction.Right:
                    {
                        moveVector.x = 1;
                        break;
                    }
            }

            {
                _characterController.Move(moveVector * Time.deltaTime * _characterData.Speed);
            }
        }

        private bool isBorder()
        {
            return true;
        }

        private bool isBorderRight()
        {
            return true;
        }

        private bool isBorderLeft()
        {
            return true;
        }

        public void Stand()
        {
            CurrentState = CharacterState.Stand;
            _characterData.ChangeState(CharacterState.Stand);
        }
    }
}