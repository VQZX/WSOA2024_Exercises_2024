using System;
using UnityEngine;

public class TimedDelete : MonoBehaviour
{
        [SerializeField]
        private float totalTime = 5f;
        
        private enum State
        {
                Nothing,
                Timing
        }

        private State state;
        private float currentTime;
        private Vector3 initialSize;
        public Action OnTimerEnded;
        
        public void ActivateTime(Action timerEnded = null)
        {
                state = State.Timing;
                currentTime = totalTime;
                initialSize = transform.localScale;
                OnTimerEnded = timerEnded;
        }

        private void Update()
        {
                if (state == State.Nothing)
                {
                        return;
                }

                currentTime -= Time.deltaTime;
                var normalizedTime = currentTime / totalTime;
                Debug.Log($"Normalized Time: {normalizedTime}");
                var nextSize = Vector3.Lerp(initialSize, Vector3.zero, 1 - normalizedTime);
                nextSize.z = 1;
                transform.localScale = nextSize;
                if (currentTime > 0)
                {
                        return;
                }

                state = State.Nothing;
                Destroy(gameObject);

        }
}