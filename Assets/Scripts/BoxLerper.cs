using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLerper : MonoBehaviour
{
    public BoxCollider referenceBegin;
    public BoxCollider referenceEnd;

    [Min(1)]
    public int slices;

    void OnDrawGizmos(){
        Gizmos.color = Color.green;
        for(int i = 0; i < slices; i++){
            float lerpConst = (i+1f)/(slices+1f);

            Vector3 pos = Vector3.Lerp(referenceBegin.transform.position, referenceEnd.transform.position, lerpConst);
            Vector3 size = Vector3.Lerp(referenceBegin.transform.localScale, referenceEnd.transform.localScale, lerpConst);
            Quaternion rot = Quaternion.Lerp(referenceBegin.transform.rotation, referenceEnd.transform.rotation, lerpConst);

            Gizmos.matrix = Matrix4x4.TRS(pos, rot, size);
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
    }
}
