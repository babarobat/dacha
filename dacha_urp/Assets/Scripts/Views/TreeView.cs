using System;
using TMPro;
using UnityEngine;

namespace Views
{
    public class TreeView : BaseView<Tree>, IStateListener
    {
        [SerializeField]
        private GameObject _primitiveState;

        [SerializeField]
        private GameObject _realState;

        [SerializeField]
        private TextMeshPro[] _texts;


        private readonly GuiStateSelector _stateSelector = new GuiStateSelector();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _stateSelector.AddState(_primitiveState);
            _stateSelector.AddState(_realState);
        }

        protected override void OnConnected()
        {
            base.OnConnected();

            foreach (var text in _texts)
            {
                text.SetText(Data.Id.ToString());
            }
        }

        public void SetState(MapObjectState state)
        {
            switch (state)
            {
                case MapObjectState.Real:
                    _stateSelector.SetState(_realState);
                    break;
                case MapObjectState.Primitives:
                    _stateSelector.SetState(_primitiveState);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}