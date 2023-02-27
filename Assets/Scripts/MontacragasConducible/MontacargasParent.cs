using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontacargasParent : MonoBehaviour {

    GameObject box;
    bool charge=false;
    public MontacargasDrive drive;
    public Transform boxes;
    

    // Update is called once per frame
    void Update ()
    {

        

        if (drive.playerDrive)
        {
            if (Input.GetKey(KeyCode.Space) && !charge)
            {
                RaycastHit hit;

                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1, Color.red);


                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),  out hit, 1f))
                {                    

                    if (hit.collider.tag.Equals("box"))
                    {                        
                        box = hit.collider.gameObject;
                        Destroy(box.GetComponent<Rigidbody>());                        
                        box.gameObject.transform.SetParent(transform);
                        charge = true;
                        
                    }
                }
                
            }

            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && charge)
            {                
                
                box.AddComponent<Rigidbody>();
                box.GetComponent<Rigidbody>().mass = 200;
                box.gameObject.transform.SetParent(boxes);
                charge = false;
                
            }
        }
    }

   


    
        
}
