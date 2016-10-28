using UnityEngine;


namespace Player
{
    public class AI_PlayerActionsController : MonoBehaviour
    {
        [System.Serializable]
        private class AI_Action
        {
            public enum Phase
            {
                Active,
                Passive
            }

            public Phase phase;
            public float duration;
            public PlayerActions[] actions;
        }

        [SerializeField]
        private AI_Action[] actions;

        [SerializeField]
        private bool isRepeat;

        private int index;
        private float nextActionTime;
        private bool isFinished;
        private bool isPhaseActive;


        private void OnEnable()
        {
            index = -1;
            nextActionTime = 0;
        }

        private void OnDisable()
        {
            index = -1;
            nextActionTime = 0;
        }

        private void Update()
        {
            if (Time.time > nextActionTime && !isFinished || Time.time > nextActionTime && isRepeat)
            {
                index++;

                if (index > actions.Length - 1)
                {
                    isFinished = true;
                    index = 0;
                }

                nextActionTime = Time.time + actions[index].duration;

                if (PlayerController.Actions != null)
                {
                    if (actions[index].phase == AI_Action.Phase.Passive)
                        PlayerController.Actions.Clear();
                    else
                        PlayerController.Actions.AddRange(actions[index].actions);
                }
            }
        }
    }
}