using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    public abstract class Subject : MonoBehaviour
    {
        // a collection of all the observers pattern of this subject
        // Lists & HashSets provide simplest setup
        // Dictionaries provides better performance for large collections
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

        protected void NotifyObservers()
        {
            _observers.ForEach((_observer) =>
            {
                _observer.OnNotify();
            });
        }
    }
}