using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button[] qualitySetting;

    PostProcessingBehaviour cameraFilter;

    public Sprite btnActivo;

    public Sprite btnDesactivado;

    private int quality;

    private void Start()
    {
        //cameraFilter = Camera.main.GetComponent<PostProcessingBehaviour>();
        AssignPostProcessing();
        SetMidQuality();
    }

    private void AssignPostProcessing()
    {
        cameraFilter = GameObject.FindWithTag("MainCamera").GetComponent<PostProcessingBehaviour>();
    }

    public void SetHighQuality()
    {
        if (cameraFilter == null)
        {
            AssignPostProcessing();
        }

        cameraFilter.profile.ambientOcclusion.enabled = true;
        cameraFilter.profile.antialiasing.enabled = true;
        cameraFilter.profile.bloom.enabled = true;
        cameraFilter.profile.vignette.enabled = true;
        cameraFilter.profile.colorGrading.enabled = true;
        cameraFilter.profile.fog.enabled = true;

        DesactivarBotones();
        qualitySetting[0].Select();
        qualitySetting[0].GetComponent<Image>().sprite = btnActivo;
        quality = 2;
    }

    public void SetMidQuality()
    {

        if (cameraFilter == null)
        {
            AssignPostProcessing();
        }

        cameraFilter.profile.ambientOcclusion.enabled = false;
        cameraFilter.profile.antialiasing.enabled = true;
        cameraFilter.profile.bloom.enabled = false;
        cameraFilter.profile.vignette.enabled = true;
        cameraFilter.profile.colorGrading.enabled = true;
        cameraFilter.profile.fog.enabled = true;

        DesactivarBotones();
        qualitySetting[1].Select();
        qualitySetting[1].GetComponent<Image>().sprite = btnActivo;
        quality = 1;
    }

    public void SetLowQuality()
    {

        if (cameraFilter == null)
        {
            AssignPostProcessing();
        }

        cameraFilter.profile.ambientOcclusion.enabled = false;
        cameraFilter.profile.antialiasing.enabled = false;
        cameraFilter.profile.bloom.enabled = false;
        cameraFilter.profile.vignette.enabled = true;
        cameraFilter.profile.colorGrading.enabled = false;
        cameraFilter.profile.fog.enabled = true;
        DesactivarBotones();

        qualitySetting[2].Select();
        qualitySetting[2].GetComponent<Image>().sprite = btnActivo;
        quality = 0;
    }

    void DesactivarBotones()
    {
        qualitySetting[0].GetComponent<Image>().sprite = btnDesactivado;
        qualitySetting[1].GetComponent<Image>().sprite = btnDesactivado;
        qualitySetting[2].GetComponent<Image>().sprite = btnDesactivado;
    }

    public void RefreshQuality(int n)
    {
        quality = n;

        switch (quality)
        {
            case 2:
                SetHighQuality();
                break;

            case 1:
                SetMidQuality();
                break;

            case 0:
                SetLowQuality();
                break;
        }

        if (Debug.isDebugBuild)
        {
            print("calidad refrescada");
        }

    }

    public void MuteSound()
    {
        AudioListener.volume = 0;
    }

    public void UnMuteSound()
    {
        AudioListener.volume = .6f;
    }


}