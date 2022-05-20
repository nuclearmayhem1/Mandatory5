using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Quests
{
    public class QuestTemplate : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text questTitleText;
        [SerializeField] private Image questStatusImage;
        [SerializeField] private Image questStatusFill;
        [SerializeField] private ProgressSprites questStatusSprites;

        public void UpdateQuestTemplate(string QuestTitle, bool QuestProgress)
        {
            questTitleText.text = QuestTitle;
            if (QuestProgress)
            {
                questStatusImage.sprite = questStatusSprites.NormalOn;
                questStatusFill.fillAmount = 0;
            }
            else
            {
                questStatusImage.sprite = questStatusSprites.NormalOff;
                questStatusFill.fillAmount = 0;
            }
        }

        public void UpdateQuestTemplate(string QuestTitle, float QuestProgress)
        {
            questTitleText.text = QuestTitle;
            questStatusImage.sprite = questStatusSprites.RadialOff;
            questStatusFill.sprite = questStatusSprites.RadialOn;
            questStatusFill.fillAmount = Mathf.Clamp01(QuestProgress);
        }

        [System.Serializable]
        struct ProgressSprites
        {
            public Sprite NormalOff;
            public Sprite NormalOn;

            public Sprite RadialOff;
            public Sprite RadialOn;
        }
    }
}