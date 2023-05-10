using UnityEngine;
using DG.Tweening;

public class SavingPanelAnimation : MonoBehaviour
{

    RectTransform[] rectTransform;   
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponentsInChildren<RectTransform>();
        rectTransform[0].DOAnchorPosX (-10, 0.6f);
       
        rectTransform[1].DOLocalRotate(new Vector3(0,360,0),3).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }

    public void StartDestroy()
    {
        CancelInvoke();
        Invoke("CompleteDestroy",3f);
        
    }

    void CompleteDestroy()
    {
        Destroy(gameObject);
    }

    
}
