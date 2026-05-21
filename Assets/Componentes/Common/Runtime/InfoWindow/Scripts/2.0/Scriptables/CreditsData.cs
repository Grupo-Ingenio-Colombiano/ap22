using System;
using System.Collections.Generic;
using UnityEngine;

namespace VP.Common.InfoWindow
{
    [CreateAssetMenu(fileName = "New CreditsData Asset", menuName = "ScriptableObjects/New CreditsData", order = 1)]
    public class CreditsData : ScriptableObject
    {
        [Serializable]
        public class Department
        {
            [TextArea(2, 5)] public string name;
            public List<string> members;
        }

        public string header;
        public List<Department> departments = new List<Department>();
    }
}