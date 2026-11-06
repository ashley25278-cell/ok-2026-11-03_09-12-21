using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public Transform objetivo;

    public float suavidad = 5f;

    public Vector2 limiteMinimo;
    public Vector2 limiteMaximo;

    private Camera camara;

    void Start()
    {
        camara = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        float mitadAlto = camara.orthographicSize;
        float mitadAncho = mitadAlto * camara.aspect;

        float x = objetivo.position.x;
        float y = objetivo.position.y;

        x = Mathf.Clamp(x,
            limiteMinimo.x + mitadAncho,
            limiteMaximo.x - mitadAncho);

        y = Mathf.Clamp(y,
            limiteMinimo.y + mitadAlto,
            limiteMaximo.y - mitadAlto);

        Vector3 posicion = new Vector3(
            x,
            y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            posicion,
            suavidad * Time.deltaTime
        );
    }
}