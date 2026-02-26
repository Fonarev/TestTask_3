using System.Collections;

using UnityEngine;

namespace Assets.Test.Scripts.FSM
{
    internal class CoroutineHandler : MonoBehaviour
    { 
        private static CoroutineHandler _instance;
        private static CoroutineHandler instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("[COROUTINE_SINGLE]");
                    _instance = go.AddComponent<CoroutineHandler>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine coroutine)
        {
            instance.StopCoroutine(coroutine);
        }
    }
}