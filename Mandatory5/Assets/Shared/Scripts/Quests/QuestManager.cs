using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Quests
{
    public class QuestManager : MonoBehaviour
    {
        private static Dictionary<uint, Quest> Quests = new Dictionary<uint, Quest>();
        public static System.Action<string> UpdateQuests = (String) => { };

        public static uint AddQuest(Quest QuestTemplate)
        {
            if (QuestTemplate.questType == Quest.Type.Invalid)
            {
                Debug.LogException(new System.ArgumentException("The quest you are trying to add is empty!"));
            }

            uint ID = GenerateUniqueID();
            Quests.Add(ID, new Quest(QuestTemplate));
            UpdateQuests.Invoke("Add");
            Debug.Log("Added quest with ID: " + ID);
            return ID;
        }

        public static void SetNormalQuestStatus(uint QuestID, bool State)
        {
            if (!Quests.ContainsKey(QuestID))
            {
                Debug.LogException(new System.ArgumentException("QuestManager does not have a quest with ID \"" + QuestID + "\""));
                return;
            }

            if (Quests[QuestID].questType == Quest.Type.Radial)
            {
                Debug.LogException(new System.ArgumentException("Quest is of type \"Radial\", but you are trying to change state as if it was of type \"Normal\""));
                return;
            }

            Quests[QuestID].normalProgress = State;
            UpdateQuests.Invoke("Update");
        }
        public static bool GetNormalQuestStatus(uint QuestID)
        {
            if (!Quests.ContainsKey(QuestID))
            {
                Debug.LogException(new System.ArgumentException("QuestManager does not have a quest with ID \"" + QuestID + "\""));
                return false;
            }

            if (Quests[QuestID].questType == Quest.Type.Radial)
            {
                Debug.LogException(new System.ArgumentException("Quest is of type \"Radial\", but you are trying to get current state as if it was of type \"Normal\""));
                return false;
            }

            return Quests[QuestID].normalProgress;
        }

        public static void SetRadialQuestStatus(uint QuestID, int State)
        {
            if (!Quests.ContainsKey(QuestID))
            {
                Debug.LogException(new System.ArgumentException("QuestManager does not have a quest with ID \"" + QuestID + "\""));
                return;
            }

            if (Quests[QuestID].questType == Quest.Type.Normal)
            {
                Debug.LogException(new System.ArgumentException("Quest is of type \"Normal\", but you are trying to change state as if it was of type \"Radial\""));
                return;
            }

            Quests[QuestID].RadialProgress = State;
            UpdateQuests.Invoke("Update");
        }
        public static int GetRadialQuestStatus(uint QuestID)
        {
            if (!Quests.ContainsKey(QuestID))
            {
                Debug.LogException(new System.ArgumentException("QuestManager does not have a quest with ID \"" + QuestID + "\""));
                return int.MinValue;
            }

            if (Quests[QuestID].questType == Quest.Type.Normal)
            {
                Debug.LogException(new System.ArgumentException("Quest is of type \"Normal\", but you are trying to get current state as if it was of type \"Radial\""));
                return int.MinValue;
            }

            return Quests[QuestID].RadialProgress;
        }

        public static void RemoveQuest(uint QuestID)
        {
            if (Quests.ContainsKey(QuestID))
            {
                Quests.Remove(QuestID);
                UpdateQuests.Invoke("Remove");
                Debug.Log("Removed quest with ID: " + QuestID);
            }
            else
            {
                Debug.LogException(new System.ArgumentException("QuestManager does not have a quest with ID \"" + QuestID + "\""));
            }
        }

        // ID stuff because lists / arrays cant be used here due to the dynamic nature to quests
        private static uint ID = uint.MinValue;
        private static uint GenerateUniqueID()
        {
            ID = ID + 1;
            return ID - 1;
        }

        public static Quest[] GetQuests(Quest.World world) // NEEDS REWORKING!!!!!
        {
            if (world == Quest.World.Invalid)
            {
                return new Quest[0];
            }

            List<Quest> quests = new List<Quest>();
            foreach (Quest quest in Quests.Values)
            {
                if (quest.questOrigin == world)
                {
                    quests.Add(quest);
                }
            }
            return quests.ToArray();
        }
    }
}