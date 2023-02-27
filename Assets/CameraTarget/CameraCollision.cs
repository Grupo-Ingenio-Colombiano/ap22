using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 0.2f;
    public float maxDistance = 2.5f;
    public float smooth = 12f;

    Vector3 dollyDir;
    Vector3 dollyDirAdjusted;
    float distance;

    public float minDistanceZoom = 0.5f;
    public float minYCameraPos = 0.4f;


    int layerMask = CreateLayerMask(true, 2, 12); //layer that the camera will ignore


    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit, layerMask))
        {
            distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        Vector3 aux = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);

        transform.localPosition = new Vector3(aux.x, transform.localPosition.y, aux.z);

    }

    public static int CreateLayerMask(bool aExclude, params int[] aLayers)
    {
        int v = 0;
        foreach (var L in aLayers)
            v |= 1 << L;
        if (aExclude)
            v = ~v;
        return v;
    }

}
