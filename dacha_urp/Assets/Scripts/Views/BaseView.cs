using UnityEngine;

namespace Views
{
    public abstract class BaseView <T>: MonoBehaviour
    {
        protected T Data { get; private set; }

        public void Awake()
        {
            OnInitialized();
        }

        public void Connect(T data)
        {
            Data = data;
            OnConnected();
        }

        protected virtual void OnConnected()
        {
            
        }

        protected virtual void OnInitialized()
        {
            
        }
    }
    public abstract class BaseView : BaseView<Empty>
    {
    }
}