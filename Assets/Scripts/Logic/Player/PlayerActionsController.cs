using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerActionsController : MonoBehaviour
    {
        private static List<PlayerActions> globalActions;
        private List<PlayerActions> localActions;

        public static List<PlayerActions> GlobalActions
        {
            get
            {
                if (globalActions == null)
                    globalActions = new List<PlayerActions>();

                return globalActions;
            }
        }

        public List<PlayerActions> LocalActions
        {
            get
            {
                if (localActions == null)
                    localActions = new List<PlayerActions>();

                return localActions;
            }
        }


        public void AddLocalAction(PlayerActions action)
        {
            if (!LocalActions.Contains(action))
                LocalActions.Add(action);
        }

        public void RemoveLocalAction(PlayerActions action)
        {
            if (LocalActions.Contains(action))
                LocalActions.Remove(action);
        }

        public void ClearLocalActions()
        {
            LocalActions.Clear();
        }

        public static void AddGlobalAction(PlayerActions action)
        {
            if (!GlobalActions.Contains(action))
                GlobalActions.Add(action);
        }

        public static void RemoveGlobalAction(PlayerActions action)
        {
            if (GlobalActions.Contains(action))
                GlobalActions.Remove(action);
        }

        public static void ClearGlobalActions()
        {
            GlobalActions.Clear();
        }
    }
}
