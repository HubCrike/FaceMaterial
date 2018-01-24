using System.Windows.Forms;
using FaceMaterial.Patter;
using System;

namespace FaceMaterial {
    class FloatingButtonMenu<T> : Control, IEvents, IValues {

        public event Action<IAdapter<T>> AddedApater;

        private FloatingButtonMenuAdapter<T> Adapter;
        private bool AdapterExists;

        public FloatingButtonMenu() {

        }

        public void InitializeEvents() => throw new System.NotImplementedException();
        public void InitializeValues() => throw new System.NotImplementedException();

        public void SetAdapter(FloatingButtonMenuAdapter<T> adapter) {
            Adapter = adapter;
        }

    }
}
