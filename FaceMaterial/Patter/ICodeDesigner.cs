using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FaceMaterial.Patter {
   
    public delegate void ValueChangeEventHandle<T>(T value);
    public delegate void PropertyChangeEventHandle<T>(T value);

    public delegate bool CompareHandle(string value, string valuetwo, bool isCompare);

    public  static class Linq {

        public static IEnumerable<T1> Where<T1>(T1 items, Func<T1, bool> function) where T1 : IEnumerable {
            foreach (T1 item in items) {
                if (function(item))
                    yield return item;
            }
        }
        public static IEnumerable<T2> Select<T1, T2>(IEnumerable<T1> items, Func<T1, T2> function) {
            foreach (T1 item in items) {
                yield return function(item);
            }
        }
        public static IEnumerable<T2> Sort<T1, T2>(IEnumerable<T1> items, Func<T1, bool> condition, Func<T1, T2> selector) {
            return from item in items where condition(item) select selector(item);
        }
        public static IEnumerable<T1> Sort<T1>(IEnumerable<T1> items, Func<T1, bool> condition, Func<T1, T1> selector) {
            return from item in items where condition(item) select selector(item);
        }
        public static IEnumerator<TOut> ForI<TSource, TOut>(this IList<TSource> source, Func<TSource, int, TOut> func) {
            if (source == null) {
                yield break;
            }

            for (int i = 0, count = source.Count; i < count; i++) {
               yield return func(source[i], i);
            }
        }
        public static void ForI<TSource, TOut>(this IList<TSource> source, Action<TSource, int> action) {
            if (source.Any()) {
                return;
            }

            for (int i = 0, count = source.Count; i < count; i++) {
                action(source[i], i);
            }
        }

    }

    public interface ICodeDesigner : IStyle, IValues, IEvents { }

    public interface IStyle {
        /// <summary>
        /// First
        /// </summary>
        void InitializeStyle();
    }
    public interface IEvents {
        /// <summary>
        /// Second
        /// </summary>
        void InitializeEvents();
    }
    public interface IValues {
        /// <summary>
        /// Third
        /// </summary>
        void InitializeValues();
    }

    internal interface IPropertyUpdater {
        void PropertyUpdate<T>(ref T field, T value);
        void PropertyUpdate<T>(ref T field, T value, Action action);
        void PropertyUpdate<T>(Action action, ref T field, T value);
    }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    internal sealed class CallerMemberNameAttribute : Attribute {
    }

    [Serializable]
    public class ValueManger {

        public event ValueChangeEventHandle<double?> MaximumChanged;
        public event ValueChangeEventHandle<double?> MinimumChanged;
        public event ValueChangeEventHandle<double?> ValueChanged;

        private double? _MaxValue;
        public double? MaxValue {
            get => _MaxValue;
            set {
                if (MaxValue == value)
                    return;

                _MaxValue = value;
                if (MaxValue <= MinValue)
                    _MaxValue = MinValue + 1;

                MaximumChanged?.Invoke(_MaxValue);
            }
        }

        private double? _MinValue;
        public double? MinValue {
            get => _MinValue;
            set {
                if (MinValue == value)
                    return;
                _MinValue = value;
                if (MinValue >= MaxValue)
                    _MinValue = MaxValue - 1;

                MinimumChanged?.Invoke(_MinValue);
            }
        }

        private double _Value;
        public double Value {
            get => _Value;
            set {
                if (Value == value)
                    return;

                _Value = value;
                if (Value > MaxValue)
                    _Value = MaxValue.Value;

                if (Value < MinValue)
                    _Value = MinValue.Value;

                ValueChanged?.Invoke(_Value);
            }
        }
    }
}
