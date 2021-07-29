using UnityEngine;

namespace Views
{
    public static class StateObjects
    {
        public static void SetState(MapObjectState state)
        {
            foreach (var obj in Object.FindObjectsOfType<GameObject>())
            {
                var listener = obj.GetComponent<IStateListener>();
                listener?.SetState(state);
            }

        }
    }
}