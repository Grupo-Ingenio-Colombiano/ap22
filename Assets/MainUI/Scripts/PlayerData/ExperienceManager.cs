using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{

    [SerializeField] private Text experienceText;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] Image experienceBar;

    [SerializeField] PlayerExperience experience;

    [SerializeField]
    UserData data;

    float exp = 0;
    float maxExperience = 500;
    private void Start()
    {
        if (experience != null)
        {
            maxExperience = experience.MaxExperience;
            experience.OnExperienceObtained += HandleExperienceBarChanged;
            experience.OnExperienceObtained += HandleExperienceChanged;
        }
        if (data.isSave == true)
        {
            exp = data.experience;
            experienceText.text = exp.ToString();
        }
    }

    private void HandleExperienceBarChanged(float percentage)
    {
        experienceBar.fillAmount = percentage;
    }

    private void HandleExperienceChanged(float units)
    {
        exp = Mathf.Ceil(units * maxExperience);

        data.experience = exp;

        experienceText.text = exp.ToString();

        if (exp >= maxExperience / 100 * 90)
        {
            star3.SetActive(true);
        }

        if (exp >= maxExperience / 100 * 65)
        {
            star2.SetActive(true);
        }

        if (exp >= maxExperience / 100 * 31)
        {
            star1.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (experience != null)
        {
            experience.OnExperienceObtained -= HandleExperienceBarChanged;
            experience.OnExperienceObtained -= HandleExperienceChanged;
        }
    }

}