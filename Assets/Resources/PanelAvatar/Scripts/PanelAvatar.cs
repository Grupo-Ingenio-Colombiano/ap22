using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PanelAvatar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText,emailText;
    [SerializeField] private UserData data;
    [SerializeField] private Sprite[] miniatures;
    [SerializeField] private Image avatarImage;

    void Start()
    {
        nameText.text = data.name;
        emailText.text = data.email;

        avatarImage.sprite = miniatures[int.Parse(data.PlayerSelected)];
    }

}
