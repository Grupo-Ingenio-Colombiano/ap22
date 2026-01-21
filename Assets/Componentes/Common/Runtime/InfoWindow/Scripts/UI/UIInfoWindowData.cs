using UnityEngine;
namespace VP.Common.InfoWindow
{
    [CreateAssetMenu(fileName = "Info Window Data", menuName = "Scriptable Objects/Info Window/Info Window Data")]
    public class UIInfoWindowData : ScriptableObject
    {
        [TextArea(5, 20)] public string content;
        public bool allowVerticalScroll;
        public bool allowHorizontalScroll;
    }
}
