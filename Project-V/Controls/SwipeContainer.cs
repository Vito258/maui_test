﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_V.Controls
{
    public class SwipeContainer : ContentView
    {
        public event EventHandler<SwipedEventArgs> Swipe;

        public SwipeContainer()
        {
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));
        }

        SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction)
        {
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer { Direction = direction };
            swipe.Swiped += (sender, e) => Swipe?.Invoke(this, e);
            return swipe;
        }
    }
}
