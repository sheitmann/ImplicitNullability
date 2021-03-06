﻿using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ImplicitNullability.Samples.CodeWithoutIN
{
    public static class External
    {
        public static string UnknownNullabilityString => null;

        public delegate void SomeDelegate(string a);

        public delegate void SomeNotNullDelegate([NotNull] string a);

        public delegate string SomeFunctionDelegate();

        public class Class
        {
            public virtual void Method(string a)
            {
            }

            public virtual string Function()
            {
                return null;
            }

            public virtual async Task<string> AsyncFunction()
            {
                await Task.Delay(0);
                return null;
            }

            public string Field;

            public virtual string SetterOnlyProperty
            {
                // ReSharper disable once ValueParameterNotUsed
                set { }
            }

            public virtual string GetterOnlyProperty => null;

            public virtual string Property { get; set; }

            public virtual string this[string a]
            {
                get { return null; }
                // ReSharper disable once ValueParameterNotUsed
                set { }
            }
        }

        public interface IInterfaceWithMethod<in T>
        {
            void Method(T a);
        }

        public interface IInterfaceWithFunction<out T>
        {
            T Function();
        }

        public interface IInterfaceWithAsyncFunction<T>
        {
            Task<T> AsyncFunction();
        }

        public interface IInterfaceWithProperty<T>
        {
            T Property { get; set; }
        }

        public abstract class BaseClassWithCanBeNull
        {
            public abstract void Method([CanBeNull] string a);

            [CanBeNull]
            public abstract string Function();

            [ItemCanBeNull]
            public abstract Task<string> AsyncFunction();

            [CanBeNull]
            public abstract string Property { get; set; }
        }

        public abstract class BaseClassWithNotNull
        {
            public abstract void Method([NotNull] string a);

            [NotNull]
            public abstract string Function();

            [ItemNotNull]
            public abstract Task<string> AsyncFunction();

            [NotNull]
            public abstract string Property { get; set; }
        }

        public interface IInterfaceWithRefAndOutParameterMethod
        {
            void Method(ref string refParam, out string outParam);
        }
    }
}
