using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FollowCameraController : MonoBehaviour
{

    public static FollowCameraController instance = null;

    public LayerMask PlayerLayer = 8;
    public float cameraToogleSpeed = 5.0f;
    public float CameraMoveSpeed = 120.0f;
    GameObject cameraFollowObj;
    public Camera camara;
    bool bloqCam = false;

    [SerializeField]
    PlayerCanMove move;
    

    float initPosZ;

    bool isThirdPerson;

    public bool IsThirdPerson
    {
        get { return isThirdPerson; }
    }

    private void Awake()
    {

        if (instance == null)           
            instance = this;        
        else if (instance != this)            
            Destroy(gameObject);

        if (GameObject.FindWithTag("Player"))
        {
            transform.position = GameObject.FindWithTag("Player").transform.position;
        }

        if (GameObject.FindWithTag("CameraTarget"))
        {
            cameraFollowObj = GameObject.FindWithTag("CameraTarget");
        }
        else
        {
            Debug.LogWarning("No existe un target para la camara");
        }

    }

    private void Start()
    {
        isThirdPerson = true;
        initPosZ = camara.gameObject.transform.localPosition.z;
    }

    private void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = cameraFollowObj.transform;
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.rotation = cameraFollowObj.transform.rotation;
    }

    private void Update()
    {
        if (cameraFollowObj == null)
        {
            cameraFollowObj = GameObject.FindWithTag("CameraTarget");
        }


        if (Input.GetKeyDown(KeyCode.C) && !bloqCam && !IsInputOnFocus())
        {
            ToggleCamera();
        }
    }


    public void ToggleCamera()
    {
        if (IsThirdPerson)
        {
            SetFirstPersonCamera();
        }
        else
        {
            SetThirdPersonCamera();
        }

        ToggleCameraState();
    }

    private void ToggleCameraState()
    {
        isThirdPerson = !IsThirdPerson;
    }

    public void SetFirstPersonCamera()
    {
        Destroy(camara.gameObject.GetComponent<CameraCollision>());
        StartCoroutine(DeleteCulling());
        StartCoroutine(AnimateCamaraZAxis(initPosZ, 0, cameraToogleSpeed));
    }

    public void SetThirdPersonCamera()
    {
        StartCoroutine(ResetCulling());
        StartCoroutine(AnimateCamaraZAxis(0, initPosZ, cameraToogleSpeed));
        camara.gameObject.AddComponent<CameraCollision>();
    }

    public IEnumerator CambioCamara(Vector3 camaraFrom, Vector3 camaraTo, float time)
    {
        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;
            camara.transform.localPosition = Vector3.Lerp(camaraFrom, camaraTo, t);

            yield return null;
        }
    }

    public IEnumerator AnimateCamaraZAxis(float dataIn, float dataOut, float time)
    {
        float t = 0;

        while (t < 1)
        {
            t += time * Time.deltaTime;

            camara.gameObject.transform.localPosition = new Vector3(camara.gameObject.transform.localPosition.x, camara.gameObject.transform.localPosition.y, Mathf.Lerp(dataIn, dataOut, t));

            yield return null;
        }

    }

    private IEnumerator ResetCulling()
    {
        yield return new WaitForSeconds(.1f);
        camara.cullingMask += 1 << PlayerLayer;
    }

    private IEnumerator DeleteCulling()
    {
        yield return new WaitForSeconds(.4f);
        camara.cullingMask -= 1 << PlayerLayer;
    }

    public void SetCameraFollow(GameObject  obj, int fieldView, bool move)
    {
        cameraFollowObj = obj;

        if (!IsThirdPerson)
            ToggleCamera();            

        camara.fieldOfView = fieldView;
        bloqCam = true;
        this.move.CanMove = move;
    }

    public void ResetCameraFollow()
    {
        cameraFollowObj = null;
        camara.fieldOfView = 60;
        bloqCam = false;
        move.CanMove = true;
    }

    bool IsInputOnFocus()
    {

        var inputs = FindObjectsOfType<InputField>();

        foreach (var item in inputs)
        {
            if(item.isFocused)
            {
                Debug.Log(item.name+ " IS FOCUSED");
                return true;
            }
            
        }

        var inputsTMP = FindObjectsOfType<TMPro.TMP_InputField>();

        foreach (var item in inputsTMP)
        {
            if(item.isFocused)
            {
                Debug.Log(item.name+ " IS FOCUSED");
                return true;
            }
            
        }

        return false;
    }
}
