using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class GuiStateSelector
    {
        private readonly List<GameObject> _states = new List<GameObject>();
        
        public void AddState(GameObject state)
        {
            _states.Add(state);
        }

        public void SetState(GameObject state)
        {
            foreach (var s in _states)
            {
                s.SetActive(s == state);
            }
        }
    }
}