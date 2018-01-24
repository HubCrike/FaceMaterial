using System.Collections.Generic;
using System.Windows.Forms;

namespace FaceMaterial.Patter {

    interface IAdapter<T> {
        Control GetView(int index, T item);
    }

    abstract class FloatingButtonMenuAdapter<T> : IAdapter<T> {
        public Control ControlTemplate;
        public List<T> Items;

        public FloatingButtonMenuAdapter(Control controlTemplate, List<T> items) {
            ControlTemplate = controlTemplate;
            Items = items;
        }

        public abstract Control GetView(int index, T item);
    }

}
