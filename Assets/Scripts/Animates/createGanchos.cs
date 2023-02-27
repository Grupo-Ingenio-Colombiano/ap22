using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createGanchos : MonoBehaviour {


    //GameObject gancho;
    [SerializeField]
    GameObject[] ganchos;

    private void Start()
    {
        StartCoroutine(CreadorDeGanchos());
        
    }

    IEnumerator CreadorDeGanchos()
    {
        for (int i = 0; i < 11; i++)
        {
            //gancho = Instantiate(Resources.Load("gancho"), transform)as GameObject;
            /*if ((i%2).Equals(0))
            {
                gancho.GetComponent<RailMove>().switchObject = 0;
                print("par");
            }
                
            else
            {
                gancho.GetComponent<RailMove>().switchObject = 1;
                print("impar");
            }*/

            ganchos[i].SetActive(true);


            yield return new WaitForSeconds(20f);
        }
    }
    

}
