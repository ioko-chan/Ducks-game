using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterControllers : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1;

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

        public void Move(Direction direction)
        {
            CurrentDirection = direction;
            CurrentState = CharacterState.Move;
            Vector2 moveVector = Vector2.zero;
            switch (direction)
            {
                case Direction.Left:
                    {
                        moveVector.x = -_speed;
                        break;
                    }
                case Direction.Right:
                    {
                        moveVector.x = _speed;
                        break;
                    }
            }
            _characterController.Move(moveVector*Time.deltaTime);
        }

        public void Stand()
        {
            CurrentState = CharacterState.Stand;
        }
    }
}