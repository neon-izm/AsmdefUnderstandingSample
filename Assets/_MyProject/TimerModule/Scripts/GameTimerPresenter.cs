using System;
using UnityEngine;

namespace AsmdefLearning.UI
{
    /// <summary>
    /// タイマーを表示する感じのプレゼンター
    /// </summary>
    public class GameTimerPresenter : MonoBehaviour,IUpdatateNotify
    {
        private float _timer = 0;

        public event Action<float> OnUpdateTimer = null;

        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime;
            OnUpdateTimer.Invoke(_timer);
        }
    }
}