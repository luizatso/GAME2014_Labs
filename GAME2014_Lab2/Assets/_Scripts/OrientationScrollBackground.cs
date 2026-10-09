using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class OrientationScrollBackground : MonoBehaviour
{
    public Vector2 scrollSpeed = new Vector2(0.5f, 0.5f);
    private RawImage image;
    private Vector2 uvOffset;

    void Start()
    {
        image = GetComponent<RawImage>();
        uvOffset = image.uvRect.position;
    }

    void Update()
    {
        uvOffset += scrollSpeed * Time.deltaTime;

        image.uvRect = new Rect(uvOffset, image.uvRect.size);
    }
}