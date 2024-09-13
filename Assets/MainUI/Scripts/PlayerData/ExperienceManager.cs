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

    [SerializeField] UserData data;
    [SerializeField] Text name;


    float exp = 0;
    float maxExperience = 500;
    private void Start()
    {
        name.text = data.name;
       
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
        exp = Mathf.Ceil(units * maxExperience);
        print("Experiencia " + exp);

        if (exp > 500)
        {
            exp = 500;
        }
        experienceText.text = exp.ToString();

        if (exp >= 450)
        {
            star3.SetActive(true);
        }

        if (exp >= 400)
        {
            star2.SetActive(true);
        }

        if (exp >= 300)
        {
            star1.SetActive(true);
        }
      
        data.experience = exp;
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