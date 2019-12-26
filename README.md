# AsmdefUnderstandingSample
Assembly Definitionを切る練習のためのプロジェクト

一般的な解説だけではなく、TestCodeやEditor拡張、ifdefがあるときの挙動はどうなっているのか、などをこのプロジェクトをasmdef対応しながら確認することを目指しています。

# DEMO
 Assets/_MyProject/_Main/Scenes/demo.unityを開いてエディタ実行をします。
 
 
# Requirement
 
* Unity2018.4.6

# Installation
git cloneしてください
 
# Usage

qiita参照
 
# Step by Step Guide
1. UtilityModuleを最初にasmdefで切る
2. ビルドが通ることを確認する
3. NetworkAccessModuleをasmdefで切って、1.をreferenceで設定する
4. ビルドが通ることを確認する
5. PlayerModuleをasmdefで切る
6. ビルドが**通らないことを確認する**
7. PlayerModuleのEditor以下をasmdefで切って、エディタのみに設定する
8. ビルドが**通ることを**確認する
6. TimerModuleをasmdefで切る
7. ビルドが通ることを確認する
8. IfdefCheckModuleをasmdefで切る
9. IfdefCheckModuleの **ScriptDefineSymbolsを設定して** 挙動の変化を確認する(DEBUGとRELEASEとASMDEFTESTを定義しています)

ここまで試したら、PlayModeTestをNetworkAccessModuleに対して設定して、以下のようなHttpAccesTest.csというテストスクリプトを書いて、NetworkAccessModuleのasmdefをテストのreferenceに設定して、PlayModeTestが動くことを確認する。
```csharp
 public class HttpAccessTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void HttpAccessTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator HttpAccessTestWithEnumeratorPasses()
        {
            var go = Resources.Load<GameObject>("MainThreadDispacher");
            GameObject.Instantiate(go);

            yield return new WaitForSeconds(1f);
            bool waiting = true;
            GetHttpStatus.GetHttpStatusTargetUrl("https://httpbin.org", i =>
            {
                Assert.AreEqual(200, i);

                waiting = false;
            });
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            while (waiting)
            {
                yield return null;
            }

            Debug.Log("テスト通りました");
        }
    }
```

# Author
neon-izm 
 
# License
Apache License 2.0