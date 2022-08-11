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
           

            if(isBorderRight() && CurrentDirection == Direction.Left)   
            {
                Move();
            }
            else if (isBorderLeft() && CurrentDirection == Direction.Right)
            {
                Move();
            }
            else if (!isBorder())
            {
                Move();
            }
        }

        private void Move()
        {
            Vector3 moveVector = Vector3.zero;
            switch (CurrentDirection)
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

            _characterController.Move(moveVector * Time.deltaTime * _characterData.Speed);
        }

        private bool isBorder()
        {
            if (isBorderRight() || isBorderLeft())
            {
                return true;
            }
            return false;
        }

        private bool isBorderRight()
        {
            if (transform.position.x+1 < _rightBorder.position.x)
            {
                return false;
            }
            return true;
        }

        private bool isBorderLeft()
        {
            if (transform.position.x-1 > _leftBorder.position.x)
            {
                return false;
            }
            return true;
        }

        public void Stand()
        {
            CurrentState = CharacterState.Stand;
            _characterData.ChangeState(CharacterState.Stand);
        }
    }
}