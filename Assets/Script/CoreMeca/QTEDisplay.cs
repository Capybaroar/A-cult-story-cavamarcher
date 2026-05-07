using UnityEngine;

public class QTEDisplay : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public void DisplayQTE(QTE qte)
    {
        spriteRenderer.sprite = qte.QTESprite;
    }
    
    public void ValidationFeedback()
    {
        spriteRenderer.color = Color.green;
    }

    public void Reset()
    {
        spriteRenderer.color = Color.white;
    }
}