using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quests
{
    [System.Serializable]
    public class Quest
    {
        public string questTitle;
        public Type questType;
        public World questOrigin;

        public bool normalProgress;

        public int RadialProgress;
        public int RadialMaxValue;

        // Dont use this because it is empty
        public Quest()
        {
            questTitle = "";
            questType = Type.Invalid;
            questOrigin = World.Invalid;

            normalProgress = false;

            RadialProgress = 0;
            RadialMaxValue = 0;
        }

        // Use this for a normal quest
        public Quest(World Origin, string Title)
        {
            questTitle = Title;
            questType = Type.Normal;
            questOrigin = Origin;

            normalProgress = false;

            RadialProgress = 0;
            RadialMaxValue = 0;
        }

        // Use this for a progressive quest
        public Quest(World Origin, string Title, int MaxValue)
        {
            questTitle = Title;
            questType = Type.Radial;
            questOrigin = Origin;

            normalProgress = false;

            RadialProgress = 0;
            RadialMaxValue = MaxValue;
        }

        // used in quest manager to make sure no referance shenanigans happen
        public Quest(Quest Copy)
        {
            questTitle = Copy.questTitle;
            questType = Copy.questType;
            questOrigin = Copy.questOrigin;

            normalProgress = Copy.normalProgress;

            RadialProgress = Copy.RadialProgress;
            RadialMaxValue = Copy.RadialMaxValue;
        }

        public enum Type
        {
            Invalid = 0,

            Normal = 1,
            Radial = 2,
        }

        public enum World
        {
            Invalid = 0,

            OverWorld = 1,
            LowerWorld = 2,
            MiddleWorld = 3,
            UpperWorld = 4,
        }
    }
}