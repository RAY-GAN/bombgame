using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cao : MonoBehaviour
{
    private Color originalcolor;
    private Texture originaltexture;
    public Camera p1camera;
    public Camera p2camera;

    // Start is called before the first frame update
    void Start()
    {
        p1camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        p2camera = GameObject.FindGameObjectWithTag("camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        originalcolor = other.GetComponent<MeshRenderer>().material.color;
        other.GetComponent<MeshRenderer>().material.color = Color.yellow;

        if (other.gameObject.CompareTag("Player2") & other.gameObject.TryGetComponent<OffscreenMarker>(out OffscreenMarker marker))
        {
            originaltexture = marker.Icon;
            marker.Icon = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<MeshRenderer>().material.color = Color.yellow;
        if (other.gameObject.CompareTag("Player1"))
        {
            p2camera.cullingMask &= ~(1 << 3);
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            p1camera.cullingMask &= ~(1 << 7);
        }

       

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<MeshRenderer>().material.color = originalcolor;

        if (other.gameObject.CompareTag("Player1"))
        {
            p2camera.cullingMask |= (1 << 3);
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            p1camera.cullingMask |= (1 << 7);
        }

        if (other.gameObject.CompareTag("Player2") & other.gameObject.TryGetComponent<OffscreenMarker>(out OffscreenMarker marker))
        {
            marker.Icon = originaltexture;
        }

    }
}
