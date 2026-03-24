using UnityEngine;

public class PixelSpriteScroller : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private int pixelsPerUnit = 16; // Match your Sprite's PPU

    private SpriteRenderer spriteRenderer;
    private Material targetMaterial;
    private float rawOffset;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        // 1. Calculate the continuous movement
        rawOffset += scrollSpeed * Time.deltaTime;

        // 2. The "Snap" Logic:
        // We multiply by PPU, round to the nearest whole number, then divide back.
        // This forces the value to jump in "pixel" increments.
        float snappedOffset = Mathf.Round(rawOffset * pixelsPerUnit) / pixelsPerUnit;

        // 3. Apply to the texture
        targetMaterial.SetTextureOffset("_MainTex", new Vector2(snappedOffset, 0));
    }
}