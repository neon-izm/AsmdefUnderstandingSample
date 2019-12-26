using System.Collections;
using AsmdefLearning.Networking;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
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
}