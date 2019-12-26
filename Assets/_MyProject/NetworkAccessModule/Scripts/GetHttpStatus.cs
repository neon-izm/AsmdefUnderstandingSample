using System;
using System.Collections;
using AsmdefLearning.Utility;
using UnityEngine;
using UnityEngine.Networking;

namespace AsmdefLearning.Networking
{
    /// <summary>
    /// 何かの通信を行う的なサンプルクラス
    /// </summary>
    public class GetHttpStatus
    {
        /// <summary>
        /// 対象URLのGetアクセスしたレスポンスコードを返す非同期な関数
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="resultAction"></param>
        public static void GetHttpStatusTargetUrl(string uri, Action<int> resultAction)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(GetHttpStatusCoroutine(uri, resultAction));
        }

        private static IEnumerator GetHttpStatusCoroutine(string url, Action<int> completed)
        {
            if (string.IsNullOrEmpty(url))
            {
                Debug.Log("url指定が空だったのでhttpbin.orgにアクセスします");
                url = "https://httpbin.org/";
            }

            UnityWebRequest request = UnityWebRequest.Get(url);

            // リクエスト送信
            yield return request.Send();

            //そのままリターンコードを返す
            completed?.Invoke((int) request.responseCode);
            Debug.Log($"{url}にアクセスした結果は{request.responseCode} で本文は {request.downloadHandler.text}");
        }
    }
}