using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    Animator anim;
    Rigidbody rb;
    CapsuleCollider capsuleCol;

    Vector3 rotationValue;
    float rot;

    bool playerCanJump = true;

    float ladderSpeed = 0;

    public PhysicMaterial con_friccion;
    public PhysicMaterial sin_friccion;

    public float jumpForce = 150f;

    [SerializeField] PlayerCanMove movementControl;

    [SerializeField]
    UserData data;

  

    void Start()
    {

        rot = 50;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCol = GetComponent<CapsuleCollider>();

        capsuleCol.material = con_friccion;
        if (data.isSave == true)
        {
            rb.transform.localPosition = data.playerPosition;
            rb.transform.localRotation = data.playerRot;
        }


    }

    void Update()
    {

        if (movementControl.CanMove && !IsInputOnFocus())
        {
            //rotacion
            float h = Input.GetAxis("Horizontal");
            rotationValue = new Vector3(0, h * 1.5f, 0);

            //desplazamiento
            float vertical = Input.GetAxis("Vertical");
            anim.SetFloat("movementSpeed", vertical);

            SetPhysicMaterial(vertical);

            //caminar - correr
            if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)))
            {
                anim.SetBool("run", true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.RightShift)))
            {
                anim.SetBool("run", false);
            }

            //salto
            if (Input.GetKeyDown(KeyCode.Space) && (playerCanJump))
            {
                StartCoroutine(Jump());
            }

            rb.transform.Rotate(rotationValue * rot * Time.deltaTime);
            rb.transform.localPosition += new Vector3(0, ladderSpeed, 0) * Time.deltaTime;
        }
        else
        {
            anim.SetFloat("movementSpeed", 0);
        }
        data.playerPosition = rb.transform.localPosition;
        data.playerRot = rb.transform.localRotation;
       
    }

    private void SetPhysicMaterial(float vertical)
    {
        if (Mathf.Epsilon < Mathf.Abs(vertical))
        {
            capsuleCol.material = sin_friccion;
        }
        else
        {
            capsuleCol.material = con_friccion;
        }
    }
   
    #region salto
    private IEnumerator Jump()
    {
        playerCanJump = false;
        rb.AddForce(transform.up * jumpForce);
        //yield return new WaitForSeconds(.2f);
        anim.SetTrigger("jump");

        yield return new WaitForSeconds(.8f);
        playerCanJump = true;
    }

    #endregion


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
