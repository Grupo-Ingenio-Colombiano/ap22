using System;
using System.Collections.Generic;
using UnityEngine;

namespace VP.Common.InfoWindow
{
    [CreateAssetMenu(fileName = "New RequirementsData Asset", menuName = "ScriptableObjects/Login/New RequirementsData", order = 1)]
    public class RequirementsData : ScriptableObject
    {
        [Serializable]
        public class Component
        {
            [TextArea(2, 5)] public string name;
            [TextArea(2, 5)] public string minimum;
            [TextArea(2, 5)] public string recommended;

            [TextArea(2, 5)] public string warningNotes;
        }

        public string header;
        public List<Component> components = new List<Component>();
    }
}