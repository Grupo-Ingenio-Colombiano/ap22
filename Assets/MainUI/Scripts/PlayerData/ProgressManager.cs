
using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{

    [SerializeField] private Image progressBar;

    [SerializeField] private Text progressPercentage;

    [SerializeField] PlayerProgress progress;


    private void Start()
    {
        if (progress != null)
        {
            progress.OnProgressMade += HandleProgressBarChanged;
            progress.OnProgressMade += HandleProgressPercentageChanged;
        }
        //if (progress.data.isSave == true)
        //{
        //   progress.CurrentProgress = progress.data.progress;
        //   progressPercentage.text = progress.data.progress.ToString() + "%";
           
        //}
    }

    private void HandleProgressBarChanged(float pct)
    {
        progressBar.fillAmount = pct;
    }

    private void HandleProgressPercentageChanged(float pct)
    {
        progressPercentage.text = Mathf.Ceil(pct * 100).ToString() + "%";

        if (Mathf.Ceil(pct * 100) > 98)
        {
            progressPercentage.text = "100%";
        }
    }

    private void OnDisable()
    {
        if (progress != null)
        {
            progress.OnProgressMade -= HandleProgressBarChanged;
            progress.OnProgressMade -= HandleProgressPercentageChanged;

        }
    }
}