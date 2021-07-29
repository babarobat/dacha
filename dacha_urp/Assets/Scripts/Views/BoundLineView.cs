using UnityEngine;

namespace Views
{
    public class BoundLineView : BaseView<(BoundPoint First, BoundPoint Second)>, IStateListener
    {
        [SerializeField]
        private LineRenderer _lineRenderer;
        
        protected override void OnConnected()
        {
            base.OnConnected();
            
            _lineRenderer.SetPosition(0,  Data.First.Position);
            _lineRenderer.SetPosition(1,  Data.Second.Position);
        }

        public void SetState(MapObjectState state)
        {
            
        }
    }
}