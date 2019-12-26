using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AsmdefLearning.Player
{
    /// <summary>
    /// PlayerMoverのインスペクタ拡張、Asmdefの影響でビルドを通らなくなったりするサンプル
    /// </summary>
    [CustomEditor(typeof(PlayerMover))]
    public class PlayerMoverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Editor拡張しています");
            EditorGUILayout.LabelField("プレイヤーの移動をつかさどります");
            EditorGUILayout.LabelField("asmdefを切るの間違えるとビルドでコケます");
            base.OnInspectorGUI();
        }
    }
}