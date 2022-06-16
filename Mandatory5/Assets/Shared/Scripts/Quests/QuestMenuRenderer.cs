using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    public class QuestMenuRenderer : MonoBehaviour // NEEDS REWORKING!!!!!
    {
        #region Update stuff
        public static Quest.World currentWorld = Quest.World.Invalid;
        private Quest.World world = Quest.World.Invalid;

        private void OnEnable()
        {
            QuestManager.UpdateQuests += UpdateQuests;
        }

        private void OnDisable()
        {
            QuestManager.UpdateQuests -= UpdateQuests;
        }

        private void FixedUpdate()
        {
            if (currentWorld != world && currentWorld != Quest.World.Invalid)
            {
                world = currentWorld;
                UpdateQuests("");
            }
        }
        #endregion

        [SerializeField] private GameObject questTemplatePrefab;
        [SerializeField] private TMPro.TMP_Text questTabTitleText;
        [SerializeField] private RectTransform questTabParent;
        [SerializeField] private Quests.QuestTabToggle questTabToggle;
        [SerializeField] private List<QuestTemplate> questTemplates = new List<QuestTemplate>();

        [SerializeField] private AudioSource questAudioSource;

        [SerializeField] private AudioClip questAddSound;
        [SerializeField] private AudioClip questProgressSound;
        [SerializeField] private AudioClip questRemoveSound;

        private void UpdateQuests(string UpdateType) // Add | Update | Remove
        {
            questTabTitleText.text = WorldText(world);
            Quest[] quests = QuestManager.GetQuests(world);

            for (int i = 0; i < quests.Length - questTemplates.Count; i++)
            {
                GameObject obj = Instantiate(questTemplatePrefab, questTabParent);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 30 + 50 * questTemplates.Count);
                questTemplates.Add(obj.GetComponent<QuestTemplate>());
            }

            for (int i = 0; i < questTemplates.Count - quests.Length; i++)
            {
                Destroy(questTemplates[questTemplates.Count - 1].gameObject);
                questTemplates.RemoveAt(questTemplates.Count - 1);
            }

            questTabToggle.tabQuestSize = questTemplates.Count * 50;

            for (int i = 0; i < quests.Length; i++)
            {
                if (quests[i].questType == Quest.Type.Normal)
                {
                    questTemplates[i].UpdateQuestTemplate(quests[i].questTitle, quests[i].normalProgress);
                }
                else if (quests[i].questType == Quest.Type.Radial)
                {
                    questTemplates[i].UpdateQuestTemplate(quests[i].questTitle, (float)quests[i].RadialProgress / (float)quests[i].RadialMaxValue);
                }
            }

            if (UpdateType == "Add")
            {
                questAudioSource.clip = questAddSound;
                questAudioSource.Play();
            }
            else if (UpdateType == "Update")
            {
                questAudioSource.clip = questProgressSound;
                questAudioSource.Play();
            }
            else if (UpdateType == "Remove")
            {
                questAudioSource.clip = questRemoveSound;
                questAudioSource.Play();
            }
        }

        private string WorldText(Quest.World Origin)
        {
            switch (Origin)
            {
                case Quest.World.Invalid:
                    return "?????? ????? ??????";

                case Quest.World.OverWorld:
                    return "Over-World quests";

                case Quest.World.LowerWorld:
                    return "Lower-World quests";

                case Quest.World.MiddleWorld:
                    return "Chick Republic quests";

                case Quest.World.UpperWorld:
                    return "Upper-World quests";

                default:
                    return "??????-World quests";
            }
        }
    }
}