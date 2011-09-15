﻿using System;
using System.Collections.Specialized;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Codeplex.Reactive.Extensions
{
    public static class ICommandExtensions
    {
        public static IObservable<EventArgs> CanExecuteChangedAsObservable<T>(this T source)
            where T : ICommand
        {
            return Observable.FromEvent<EventHandler, EventArgs>(
                h => (sender, e) => h(e),
                h => source.CanExecuteChanged += h,
                h => source.CanExecuteChanged -= h);
        }
    }
}