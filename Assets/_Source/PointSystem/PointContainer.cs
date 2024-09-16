using System;

namespace CometSystem
{
    public class PointContainer
    {
        private int _points;

        public event Action<int> OnPointsCountChange;

        public void AddPoint()
        {
            _points++;
            OnPointsCountChange?.Invoke(_points);
        }
    }
}