using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsmdefLearning.Utility
{

    
    /// <summary>
    /// なんとなく作ったメインスレッドディスパッチャー
    /// Prefabをシーンにおいておく必要があるので、UniRXとかが使えるならそっちを使った方が良いよ
    /// </summary>
    public class UnityMainThreadDispatcher : MonoBehaviour {

        private static readonly Queue<Action> _executionQueue = new Queue<Action>();

        public void Update() {
            lock(_executionQueue) {
                while (_executionQueue.Count > 0) {
                    _executionQueue.Dequeue().Invoke();
                }
            }
        }

        /// <summary>
        /// Locks the queue and adds the IEnumerator to the queue
        /// </summary>
        /// <param name="action">IEnumerator function that will be executed from the main thread.</param>
        public void Enqueue(IEnumerator action) {
            lock (_executionQueue) {
                _executionQueue.Enqueue (() => {
                    StartCoroutine (action);
                });
            }
        }

        /// <summary>
        /// Locks the queue and adds the Action to the queue
        /// </summary>
        /// <param name="action">function that will be executed from the main thread.</param>
        public void Enqueue(Action action)
        {
            Enqueue(ActionWrapper(action));
        }
        IEnumerator ActionWrapper(Action action)
        {
            action();
            yield return null;
        }


        private static UnityMainThreadDispatcher _instance = null;

        public static bool Exists() {
            return _instance != null;
        }

        public static UnityMainThreadDispatcher Instance() {
            if (!Exists ()) {
                throw new Exception ("シーンにこのスクリプトを張り付けたGameObjectを置いておいてください！");
            }
            return _instance;
        }


        void Awake() {
            if (_instance == null) {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

        void OnDestroy() {
            _instance = null;
        }


    }
}