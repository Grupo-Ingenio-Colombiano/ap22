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


    float maxExperience = 500;
    private void Start()
    {
        if (experience != null)
        {
            maxExperience = experience.MaxExperience;
            experience.OnExperienceObtained += HandleExperienceBarChanged;
            experience.OnExperienceObtained += HandleExperienceChanged;
        }
    }

    private void HandleExperienceBarChanged(float percentage)
    {
        experienceBar.fillAmount = percentage;
    }

    private void HandleExperienceChanged(float units)
    {
        float exp = Mathf.Ceil(units * maxExperience);

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