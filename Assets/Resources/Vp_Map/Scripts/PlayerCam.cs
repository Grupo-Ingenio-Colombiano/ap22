using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Sprite indicatorSprite;
    [SerializeField] private string mapLayer = "Map";
    
    [SerializeField] private Color backgroundColor = new Color32(0,32,37,255);
    [SerializeField] private RenderTexture miniMapTexture;
    void Start()
    {
        SetupIcon();
        SetupCamera();
    }

    private void SetupIcon()
    {
        GameObject arrowObject = new GameObject("PlayerArrow");
        arrowObject.transform.parent = this.transform;
        arrowObject.transform.localPosition = Vector3.zero;
        arrowObject.transform.localScale = new Vector3(0.6f,0.6f,1);
        arrowObject.transform.localRotation = Quaternion.Euler(new Vector3(90,0,0));;
        arrowObject.AddComponent<MapArrow>();

        SpriteRenderer playerSprite = arrowObject.AddComponent<SpriteRenderer>();
        playerSprite.sprite = indicatorSprite;
        playerSprite.sortingOrder=10;

        arrowObject.layer = LayerMask.NameToLayer(mapLayer);
    }

    private void SetupCamera()
    {
        GameObject camObject = new GameObject("MapCam");
        camObject.transform.parent = this.transform;
        

        camObject.transform.localPosition = new Vector3(0,60,0);
        camObject.transform.localRotation = Quaternion.Euler(90,0,0);

        Camera cam = camObject.AddComponent<Camera>();
        LayerMask mask = LayerMask.NameToLayer(mapLayer);
        cam.cullingMask = (1<<mask);

        cam.fieldOfView = 60;

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = backgroundColor;

        cam.targetTexture = miniMapTexture;
    }
}
