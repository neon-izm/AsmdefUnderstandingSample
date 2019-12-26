using UnityEngine;

namespace AsmdefLearning.Environment
{
    /// <summary>
    /// ifdefが切ってある場合にasmdefはどうなるのかをチェックする
    /// </summary>
    public class EnvironmentCheck
    {
        public EnvironmentCheck()
        {
#if ASMDEFTEST
            Debug.Log("This is ASMDEF");            
#elif RELEASE
            Debug.Log("This is Release"); 
#elif DEBUG
            Debug.Log("This is Debug");
#else
            Debug.Log("This is Some others");
#endif
            
#if UNITY_STANDALONE_WIN
            Debug.Log("Windowsになってます");            
#elif UNITY_IOS
            Debug.Log("iOSになってます"); 
#elif UNITY_ANDROID
            Debug.Log("Androidになってます"); 
#elif UNITY_STANDALONE_OSX
            Debug.Log("MacOSになってます");
#else
            Debug.Log("他のプラットフォームです");
#endif
        }
    }
}