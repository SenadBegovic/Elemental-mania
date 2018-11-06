using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScale : MonoBehaviour {

    public Vector2 m_FixedScale;

    private void Start()
    {
        UpdateScale();
    }

    private void OnValidate()
    {
        UpdateScale();
    }

    private void UpdateScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
        var res = transform.localToWorldMatrix;
        Vector3 worldScaleVector = new Vector3(res.GetColumn(0).magnitude, res.GetColumn(1).magnitude);
        Debug.Log(worldScaleVector);
        transform.localScale = new Vector3(m_FixedScale.x / worldScaleVector.x , m_FixedScale.y / worldScaleVector.y , 1);
   
    }

    // Update is called once per frame
    void Update () {
        if(transform.hasChanged)
        {
            UpdateScale();
            transform.hasChanged = false;
        }
	}
}
