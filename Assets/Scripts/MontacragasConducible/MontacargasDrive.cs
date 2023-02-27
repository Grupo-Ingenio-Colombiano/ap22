using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontacargasDrive : MonoBehaviour, ItemActions    {

    public Transform posPlayer;

    public Transform posFinish;

    public PlayerCanMove move;

    public Camera auxiliarCamera;

    public AudioSource engineSoundControl;

    public AudioSource hoisSoundControl;

    public AudioSource shortSoundControl;

    public AudioClip elevateStop;

    public AudioClip startEngine;

    public AudioClip stopEngine;

    public AudioClip acelerate;

    public AudioClip elevate;

    public Rigidbody rigidBody;    

    public Transform rotor;

    public bool playerDrive = false;

    float rot = 30;

    float speed = 100;

    Vector3 rotationValue;

    float heightRotor = 0.37f;

    public void CustomAction()
    {
        var player = GameObject.FindWithTag("Player");
        


        if (!playerDrive)
        {
            auxiliarCamera.enabled = true;
            move.CanMove = false;
            shortSoundControl.PlayOneShot(startEngine);
            playerDrive = true;
            rigidBody.useGravity= true;
            player.transform.position = posPlayer.position;
            player.transform.rotation = posPlayer.rotation;
            player.transform.SetParent(posPlayer);
            player.GetComponent<Animator>().SetTrigger("drive");
            player.GetComponent<Rigidbody>().isKinematic=true;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Collider>().enabled= false;
            player.GetComponent<Animator>().applyRootMotion = false;
            
            engineSoundControl.Play();
            
        }
        else
        {
            engineSoundControl.Stop();
            shortSoundControl.PlayOneShot(stopEngine);
            auxiliarCamera.enabled = false;
            move.CanMove = true;
            playerDrive = false;
            rigidBody.useGravity = false;
            player.transform.position = posFinish.position;            
            player.transform.parent = posPlayer;
            player.transform.SetParent(null);
            player.GetComponent<Animator>().Play("Idle", 0);            
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Collider>().enabled = true;
            player.GetComponent<Animator>().applyRootMotion = true;
            
        }
    }

    public void StartDrive()
    {
        
        var inventory = FindObjectOfType(typeof(Inventory)) as Inventory;

        if (inventory.inventoryList[inventory.indice].itemName.Equals("Llave del montacargas"))
        {
            if (!inventory.inventoryList[inventory.indice].isNowEquiped)
            {
                inventory.inventoryList[inventory.indice].isNowEquiped = true;
            }

            else
            {
                inventory.inventoryList[inventory.indice].isNowEquiped = false;
            }
        }
    } 
	
	void Update ()
    {

        if (playerDrive)
        {
            //rotacion
            float h = Input.GetAxis("Horizontal");
            rotationValue = new Vector3(0, h * 1.5f, 0);

            //desplazamiento
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                shortSoundControl.PlayOneShot(acelerate);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                shortSoundControl.PlayOneShot(acelerate);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                shortSoundControl.Stop();
            }

            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                shortSoundControl.Stop();
            }


            //andar - acelerar
            if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)))
            {
                speed = 250;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.RightShift)))
            {
                speed = 100;
            }

            //control rotor
            if (Input.GetKey(KeyCode.Space))
            {
                if (heightRotor < 2.3f)
                {
                    heightRotor += 1 * Time.deltaTime;
                    
                }                   
                
            }

            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                if (heightRotor > 0.37f)
                {
                    heightRotor -= 1 * Time.deltaTime;                    
                    
                }                    
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (heightRotor < 2.3f)
                {
                    
                    hoisSoundControl.PlayOneShot(elevate);
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                if (heightRotor > 0.37f)
                {
                    
                    hoisSoundControl.PlayOneShot(elevate);
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.Space))
            {
                hoisSoundControl.Stop();
                hoisSoundControl.PlayOneShot(elevateStop);
            }

            rigidBody.transform.Rotate(rotationValue * rot * Time.deltaTime);
            rigidBody.velocity = transform.forward * (vertical*speed) *Time.deltaTime;
            rotor.transform.localPosition = new Vector3(rotor.transform.localPosition.x, heightRotor, rotor.transform.localPosition.z);
        }
        
    }
   
}
