using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[AddComponentMenu("MiniMap/Map marker")]
public class MapMarker : MonoBehaviour
{

    #region Public

    /* Sprite that will be shown on the map
	 */
    public Sprite markerSprite;

    /* Size of the marker on the map (width & height)
	 */
    public float markerSize = 6.5f;

    /* Enables or disables this marker on the map
	 */
    public bool isActive = true;

    [SerializeField] UserData userData;

    public Image MarkerImage
    {
        get
        {
            return markerImage;
        }
    }

    //public GameObject personaje;

    #endregion

    #region Private

    private Image markerImage;

    #endregion

    #region Unity methods

    void Start()
    {
        if (!markerSprite)
        {
            Debug.LogError(" Please, specify the marker sprite.");
        }
        GameObject markerImageObject = new GameObject("Marker");
        markerImageObject.AddComponent<Image>();
        MapCanvasController controller = MapCanvasController.Instance;
        if (!controller)
        {
            Destroy(gameObject);
            return;
        }
        markerImageObject.transform.SetParent(controller.MarkerGroup.MarkerGroupRect);
        markerImage = markerImageObject.GetComponent<Image>();
        markerImage.sprite = markerSprite;
        markerImage.rectTransform.localPosition = Vector3.zero;
        markerImage.rectTransform.localScale = Vector3.one;
        markerImage.rectTransform.sizeDelta = new Vector2(markerSize, markerSize);
        markerImage.gameObject.SetActive(false);
        
        if(userData.isSave != false)
        {
            setLocalPos(userData.markerCanvas);
            markerImage.rectTransform.localPosition = userData.markerCanvas;
        }
    }
      

    void Update()
    {
        MapCanvasController controller = MapCanvasController.Instance;
        if (!controller)
        {
            return;
        }
        MapCanvasController.Instance.checkIn(this);

        if (this.gameObject.tag == "Player")
        {
            markerImage.rectTransform.eulerAngles = new Vector3(0, 0, -gameObject.transform.eulerAngles.y + 180);
        }
        else
        {
            markerImage.rectTransform.rotation = Quaternion.identity;
        }
    }

    void OnDestroy()
    {
        if (markerImage)
        {
            Destroy(markerImage.gameObject);
        }
    }

    #endregion

    #region Custom methods

    public void show()
    {
        markerImage.gameObject.SetActive(true);
    }

    public void hide()
    {
        markerImage.gameObject.SetActive(false);
    }

    public bool isVisible()
    {
        return markerImage.gameObject.activeSelf;
    }

    public Vector3 getPosition()
    {
        if (this.gameObject.tag != "Player")
        {
            userData.indicator = gameObject.transform.position;
        }
     
        return gameObject.transform.position;
    }

    public void setLocalPos(Vector3 pos)
    {
        markerImage.rectTransform.localPosition = pos;
        if (this.gameObject.tag != "Player")       {
            userData.markerCanvas =pos;          
        }
      

    }

    public void setOpacity(float opacity)
    {
        markerImage.color = new Color(1.0f, 1.0f, 1.0f, opacity);
    }

    #endregion
}
