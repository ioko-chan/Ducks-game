using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Gameplay.CharacterControllers;

namespace Gameplay
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField]
        private float _speed;
        public float Speed => _speed;

        [SerializeField]
        private Direction _direction;
        public Direction Direction => _direction;

        [SerializeField]
        private CharacterState _characterState;
        public CharacterState CharacterState => _characterState;

        [SerializeField]
        private Vector3 _position;
        public Vector3 Position => _position;

        public void ChangeDirection(Direction direction)
        {
            _direction = direction;
        }

        public void ChangeState(CharacterState newState)
        {
            _characterState = newState;
        }

        public void ChangePosition(Vector3 position)
        {
            _position = position;
        }
    }
}