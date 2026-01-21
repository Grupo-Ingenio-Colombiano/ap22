using UnityEngine;
using UnityEngine.UI;
namespace VP.Common.InfoWindow
{
    public class ButtonSound : MonoBehaviour
    {
        [SerializeField] private AudioClip buttonSound;
        [SerializeField] private Button button;
        void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }

            button.onClick.AddListener(PlaySoundOnClick);
        }

        private void PlaySoundOnClick()
        {
            //AudioManager.instance.PlayNewSFX(buttonSound);
        }
    }

}
