using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> typeBindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsInterface || !interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException("Invalid binding. The implementation type must implement the interface type.");
            }

            typeBindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            if (!typeBindings.TryGetValue(typeof(T), out var implementationType))
            {
                throw new InvalidOperationException($"No binding found for interface type {typeof(T)}");
            }

            return (T)Activator.CreateInstance(implementationType);
        }
    }
}