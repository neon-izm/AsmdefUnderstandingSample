using AsmdefLearning.Environment;
using AsmdefLearning.Networking;
using UnityEngine;

namespace AsmdefLearning
{
    /// <summary>
    /// なんも実用的じゃないクラス
    /// </summary>
    public class NetworkAccessCheck : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EnvironmentCheck environmentCheck = new EnvironmentCheck();

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.LogError("インターネットがありません");
                return;
            }

            GetHttpStatus.GetHttpStatusTargetUrl("https://httpbin.org",
                i => { Debug.Log($"ネットワークにアクセスできました return code:{i}"); });
        }
    }
}