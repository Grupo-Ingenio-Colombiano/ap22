using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DontItemGood : MonoBehaviour
{
    [SerializeField]
    GameObject npcSSGT;

    [SerializeField]
    GameObject npcSSGTItems;

    [SerializeField]
    GameObject transition;    

    [SerializeField]
    Image transitionImage;

    [SerializeField]
    Image logoTransition;

    [SerializeField]
    PlayerCanMove move;

    [SerializeField]
    UIDialogManager dialog;



    GameObject player;

    Color color = Color.white;

    private void OnEnable()
    {
        transition.SetActive(true);
        color.a = 0;
        transitionImage.color = color;
        logoTransition.color = color;       
        StartCoroutine(AnimTransition());
        player = GameObject.FindWithTag("Player");
        move.CanMove = false;
        npcSSGT.SetActive(false);
        npcSSGTItems.SetActive(true);
    }
   

    IEnumerator AnimTransition()
    {
        for (float i = 0; i < 1; i += 0.02f)
        {
            color.a = i;
            transitionImage.color = color;
            logoTransition.color = color;
            yield return null;
        }   
               
      
        player.transform.position = new Vector3(40.7f, 0, -18.2f);
        player.transform.rotation = Quaternion.Euler(0,-186,0);

        yield return new WaitForSecondsRealtime(1);

        for (float i = 1; i > 0; i -= 0.02f)
        {
            color.a = i;
            transitionImage.color = color;
            logoTransition.color = color;
            yield return null;
        }

        transition.SetActive(false);
        SoundManager.Instance().PlayFail();

        dialog.Talk();
    }

    public void EndAlertMesagge()
    {
        move.CanMove = true;
        npcSSGTItems.SetActive(false);
        npcSSGT.SetActive(true);
        gameObject.SetActive(false);
    }

    
}
