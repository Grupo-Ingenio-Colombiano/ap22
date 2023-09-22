using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Creator : MonoBehaviour
{
    [Header("Map sprite settings")]
    [SerializeField] private Sprite MapImage;
    [SerializeField] private Vector3 mapPosition = new Vector3(32.5f,0,-51);
    [SerializeField] private Vector3 mapRotation = new Vector3(90,0,0);
    [SerializeField]private Vector3 mapScale= new Vector3(12.3f,12.3f,0);
    [SerializeField] private string layerName = "Map";
    private GameObject mapSprite;
    private SpriteRenderer mapRender;

    [Header("Map Camera settings")]
    [SerializeField] private Vector3 camPosition = new Vector3(25,100,-45);
    [SerializeField] private Vector3 camRotation = new Vector3(90,0,0);

    [SerializeField] private Color backgroundColor =new Color32(0,32,37,255);
    [SerializeField] private RenderTexture fullMapTexture;

    // Start is called before the first frame update
    void Start()
    {   
        SetUpSprite();
        SetupCamera();
    }

    private void SetUpSprite()
    {
        mapSprite = new GameObject("MapSprite");
        mapSprite.transform.parent = this.transform;

        mapSprite.transform.localPosition = mapPosition; 
        mapSprite.transform.localScale = mapScale;
        mapSprite.transform.rotation = Quaternion.Euler(mapRotation);

        mapRender= mapSprite.AddComponent<SpriteRenderer>();
        mapRender.sprite = MapImage;

        LayerMask mask = LayerMask.NameToLayer(layerName);
        mapSprite.gameObject.layer = mask;

    }

    private void SetupCamera()
    {
        GameObject camObject = new GameObject("MapCam");
        camObject.transform.parent = this.transform;
        

        camObject.transform.position = camPosition;
        camObject.transform.rotation = Quaternion.Euler(camRotation);

        Camera cam = camObject.AddComponent<Camera>();
        LayerMask mask = LayerMask.NameToLayer(layerName);
        Debug.Log(cam.cullingMask);
        cam.cullingMask = (1<<mask);

        cam.orthographic = true;
        cam.orthographicSize = 120;

        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = backgroundColor;

        cam.targetTexture = fullMapTexture;

        GameObject.FindObjectOfType<Map>(true).cam = cam;
    }

}
