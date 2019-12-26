using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsmdefLearning.UI
{
    /// <summary>
    /// インタフェースを含むクラスがasmdefでどう振舞うかチェックするためのもの
    /// </summary>
    public interface IUpdatateNotify
    {
        event Action<float> OnUpdateTimer;
    }
}