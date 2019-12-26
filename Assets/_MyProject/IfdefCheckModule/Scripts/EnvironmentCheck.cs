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
#if DEBUG
            Debug.Log("This is Debug");            
#elif RELEASE
            Debug.Log("This is Release"); 
#elif ASMDEFTEST
            Debug.Log("This is Asmdef Test");
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