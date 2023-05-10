
using UnityEngine;

public class SavingPanelManager : MonoBehaviour
{
   public void StartDestroy()
    {
        CancelInvoke();
        Invoke("CompleteDestroy",5f);
        
    }

    void CompleteDestroy()
    {
        Destroy(gameObject);
    }
}
