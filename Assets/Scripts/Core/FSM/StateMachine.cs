using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

namespace FSM
{
    public class StateMachine : MonoBehaviour
    {
        BaseState _currentState;
        void Start()
        {
            _currentState = GetInitialState();
            if (_currentState != null)
                _currentState.Enter();
        }


        void Update()
        {
            if (_currentState != null)
                _currentState.UpdateLogic();
        }

        void LateUpdate()
        {
            {
                if (_currentState != null)
                    _currentState.UpdatePhysics();
            }
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }

        public void ChangeState(BaseState newState)
        {
            _currentState.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        public BaseState CurrentState()
        {
            return _currentState;
        }
        
        //Observers Pattern
        private List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // protected void NotifyObservers(string action)
        // {
        //     _observers.ForEach((_observer) => 
        //     {
        //         _observer.OnNotify(action);
        //     })
        // }

        public void NotifyObservers(EPState pState)
        {
            _observers.ForEach((_observer) =>
            {
                _observer.OnNotify(pState);
            });
        }
    }
} 