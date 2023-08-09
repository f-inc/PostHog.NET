﻿using System.Threading;

namespace PostHog.Stats
{
    public class Statistics
    {
        private int _submitted;

        private int _succeeded;

        private int _failed;

        public int Submitted => _submitted;

        public int Succeeded => _succeeded;

        public int Failed => _failed;

        internal void IncrementSubmitted() => Increment(ref _submitted);

        internal void IncrementSucceeded() => Increment(ref _succeeded);

        internal void IncrementFailed() => Increment(ref _failed);

        private void Increment(ref int value)
        {
            if (value == int.MaxValue)
                Interlocked.Add(ref value, -value);
            else
                Interlocked.Increment(ref value);
        }
    }
}