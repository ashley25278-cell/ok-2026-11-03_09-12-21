using UnityEngine;

public class Cereza : MonoBehaviour
{
    public int puntos = 5;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Aguila"))
        {
            Debug.Log("¡Cereza recogida! - " + puntos + " puntos");
            Destroy(gameObject);
        }
    }
}