﻿using System;
using System.Collections.Generic;

namespace Kf.Common.Defensive.Possibly
{    
    public interface IPossible<TConcrete> : IPossiblyHaveAValue
    {
        /// <summary>
        /// Executes an action if a value is present.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        void Execute(Action<TConcrete> action);

        /// <summary>
        /// Maps the value, if present, to another type.
        /// </summary>
        /// <typeparam name="TResult">The type to map the TConcrete value to.</typeparam>
        /// <param name="mapping">The logic to map an object of TConcrete to TResult.</param>        
        IPossible<TResult> Map<TResult>(Func<TConcrete, TResult> mapping);

        /// <summary>
        /// Gets the value if present, otherwise calls upon the defaultValueProvider function to provide one.
        /// </summary>
        /// <param name="defaultValueProvider">The logic to provide a default TConcrete value.</param>        
        TConcrete GetValue(Func<TConcrete> defaultValueProvider);

        /// <summary>
        /// Gets the value if present, otheriwse returns the provided defaultValue.
        /// </summary>
        /// <param name="defaultValue">The default value to be returned when no value is present.</param>        
        TConcrete GetValue(TConcrete defaultValue);

        /// <summary>
        /// Returns an enumerable sequence of 1 or more TConcrete values if present, otherwise returns an empty sequence of TConcrete.
        /// </summary>
        IEnumerable<TConcrete> AsEnumerable();
    }
}
