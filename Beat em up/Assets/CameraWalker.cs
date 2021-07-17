using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWalker : MonoBehaviour
{
    public Transform player;

    public Camera Camera;

    public float left;
    public float right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        float x = Mathf.Clamp(player.localPosition.x, left, right);
        //Debug.Log(x);
        Camera.transform.localPosition = new Vector3(x, Camera.transform.localPosition.y, Camera.transform.localPosition.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(left,100),new Vector3(left,-100));
        Gizmos.DrawLine(new Vector3(right, 100), new Vector3(right, -100));
    }
}
