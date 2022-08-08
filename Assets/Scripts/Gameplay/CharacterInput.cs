using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

namespace Gameplay
{
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField]
        private EventListener _updateEventListener;

        [SerializeField]
        private CharacterControllers _characterControllers;

        private void OnEnable()
        {
            _updateEventListener.OnEventHappened += UpdateBehaviour;
        }

        private void OnDisable()
        {
            _updateEventListener.OnEventHappened -= UpdateBehaviour;
        }

        public void UpdateBehaviour()
        {
            Move();
        }
        
        public void Move()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _characterControllers.Move(CharacterControllers.Direction.Left);
            }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _characterControllers.Move(CharacterControllers.Direction.Right);
            }
            else
            {
                _characterControllers.Stand();
            }           
        }
    }
}