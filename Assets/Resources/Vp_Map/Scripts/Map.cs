using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private string mapTitle;
    public Camera cam;
    Vector3 initialPos;
    public Button moveBtn;
    Animator moveAnim;
    public float sensitivity;

    float moveX = 0f;
    float moveZ = 0f;

    public bool drag;
    public bool canDrag;

    [SerializeField] private Button zoomIn,zoomOut;

    private Transform playerArrow;
    private Vector2 oldPlayerArrowPos;

    void Start()
    {
        gameObject.SetActive(false);
        initialPos = cam.transform.localPosition;
        moveAnim = moveBtn.GetComponent<Animator>();
        titleText.text = mapTitle;
    }

    public void Update()
    {
        if (canDrag)
        {
            if (drag)
            {
                if (moveX != 0)
                {
                    moveX = 0;
                }

                if (moveZ != 0)
                {
                    moveZ = 0;
                }
                moveX += Input.GetAxis("Mouse X") * sensitivity;
                moveZ += Input.GetAxis("Mouse Y") * sensitivity;

                cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + moveX, cam.transform.localPosition.y, cam.transform.localPosition.z + moveZ);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                drag = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                drag = false;
            }
        }
        else
        {
            moveAnim.SetTrigger("Normal");

        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }

    }

    private void OnEnable() 
    {
        if(!playerArrow)
        {
            playerArrow = GameObject.FindObjectOfType<MapArrow>(true).transform;
            oldPlayerArrowPos = playerArrow.transform.localScale;
        }    

        playerArrow.transform.localScale = new Vector3(playerArrow.transform.localScale.x / 2,playerArrow.transform.localScale.y / 2,playerArrow.transform.localScale.z / 2);
    }

    public void ResePos()
    {
        cam.transform.localPosition = new Vector3(25,100,-45);
        cam.orthographicSize = 110;
    }

    public void ZoomIn()
    {
        if (cam.orthographicSize > 10)
        {
            cam.orthographicSize -= 5;
        }

        zoomIn.interactable = cam.orthographicSize != 10;    
        zoomOut.interactable = cam.orthographicSize != 120;
    }

    public void ZoomOut()
    {
        if (cam.orthographicSize < 120)
        {
            cam.orthographicSize += 5;
        }

        zoomOut.interactable = cam.orthographicSize != 120;    
        zoomIn.interactable = cam.orthographicSize != 10;
    }

    public void StartDrag()
    {
        canDrag = true;
    }

    public void EndDrag()
    {
        canDrag = false;

    }

    private void OnDisable() 
    {
        EndDrag();
        ResePos();
        playerArrow.transform.localScale = oldPlayerArrowPos;
    }
}
