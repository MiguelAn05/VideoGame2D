using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Sprite dayBackground;
    public Sprite nightBackground;
    public SpriteRenderer backgroundRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            backgroundRenderer.sprite = nightBackground; // Cambia al fondo de noche
            // Opcional: Puedes ajustar otros parámetros de iluminación según la hora del día
        }
    }
}
