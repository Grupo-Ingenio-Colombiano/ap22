using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Vp_Packages
{
    public class PlayerPositionSetter : MonoBehaviour
    {
        [SerializeField] private Vector3 goPosition;
        private void Start() 
        {
            GetComponent<Button>().onClick.AddListener(SendToPosition);    
        }
        private void SendToPosition()
        {
            GameObject player = GameObject.FindWithTag("Player");
            if(player)
            {
                player.transform.position = goPosition;
            }
        }
    }

}
