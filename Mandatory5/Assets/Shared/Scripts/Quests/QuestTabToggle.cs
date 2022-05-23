using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    public class QuestTabToggle : MonoBehaviour
    {
        [SerializeField] private RectTransform tabQuestMenu;
        [SerializeField] private float tabMenuAnimationSpeed = 2;
        [HideInInspector] public float tabQuestSize = 0;

        private Vector2 size = new Vector2(300, 80);
        private bool menuOpen = true;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuOpen = !menuOpen;
            }

            if (menuOpen)
            {
                if (size.y < tabQuestSize + 80)
                {
                    size.y += tabQuestSize * Time.deltaTime * tabMenuAnimationSpeed;
                }
            }
            else
            {
                if (size.y > 80)
                {
                    size.y -= tabQuestSize * Time.deltaTime * tabMenuAnimationSpeed;
                }
            }

            size.y = Mathf.Clamp(size.y, 80, tabQuestSize + 80);
            tabQuestMenu.sizeDelta = size;
        }
    }
}
