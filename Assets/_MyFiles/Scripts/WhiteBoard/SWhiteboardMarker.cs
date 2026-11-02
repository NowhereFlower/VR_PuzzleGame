using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SWhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform tip;
    [SerializeField] private int penSize = 5;

    private Renderer renderer; 
    private Color[] colors;
    private float tipHeight;
    private RaycastHit hit;
    private SWhiteboard whiteboard;
    private Vector2 touchPos;
    private Vector2 lastTouchPos;
    private Quaternion lastTouchRot;
    private bool touchLastFrame;
    private void Start()
    {
        renderer = tip.GetComponent<Renderer>();
        colors = Enumerable.Repeat(renderer.material.color, penSize * penSize).ToArray();
        tipHeight = tip.localScale.y;
    }

    private void Update()
    {
        Draw();

        //Testimg and seeing where it points at
        Debug.DrawRay(tip.position, tip.up, Color.red);
        if (Physics.Raycast(tip.position, tip.up, out RaycastHit hit, 0.5f))
        {
            Debug.Log("Ray hit: " + hit.transform.name); 
        }
    }

    private void Draw()
    {
        if(Physics.Raycast(tip.position, transform.up, out hit, tipHeight))
        {
            //Checks if hit is the whiteboard
            if (hit.transform.CompareTag("Whiteboard"))
            {
                if(whiteboard == null)
                {
                    whiteboard = hit.transform.GetComponent<SWhiteboard>();
                }

                touchPos = new Vector2(hit.textureCoord.x, hit.textureCoord.y);

                var x = (int)(touchPos.x * whiteboard.textureSize.x - (penSize / 2));
                var y = (int)(touchPos.y * whiteboard.textureSize.y - (penSize / 2));

                if(y < 0 || y > whiteboard.textureSize.y || x < 0 || x > whiteboard.textureSize.x)
                {
                    return;
                }

                if (touchLastFrame)
                {
                    whiteboard.texture.SetPixels(x, y, penSize, penSize, colors);

                    for(float i = 0.01f; i < 1.00f; i += 0.01f)
                    {
                        var lerpx = (int)Mathf.Lerp(lastTouchPos.x, x, i);
                        var lerpy = (int)Mathf.Lerp(lastTouchPos.y, y, i);
                        whiteboard.texture.SetPixels(lerpx, lerpy, penSize, penSize, colors);
                    }

                    transform.rotation = lastTouchRot;
                    whiteboard.texture.Apply();
                }

                lastTouchPos = new Vector2 ( x, y) ;
                lastTouchRot = transform.rotation;
                touchLastFrame = true;
                return;
            }
        }

        whiteboard = null;
        touchLastFrame = false;
    }
}
