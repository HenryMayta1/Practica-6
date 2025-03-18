using UnityEngine;

public class Luna : MonoBehaviour
{
    public Transform tierra; // Referencia a la Tierra
    public float velocidadOrbita = 40f; // Velocidad de órbita de la Luna
    public float distanciaALaTierra = 2f; // Distancia de la Luna a la Tierra
    public float velocidadRotacion = 50f; // Velocidad de rotación de la Luna
    public float velocidadEscalado = 0.5f; // Velocidad de cambio de escala
    public float escalaMinima = 0.8f; // Escala mínima de la Luna
    public float escalaMaxima = 1.2f; // Escala máxima de la Luna

    private float tiempoEscalado = 0f;

    void Update()
    {
        // Control mediante teclado
        bool traslacionActiva = Input.GetKey(KeyCode.T); // Traslación (presionar 'T')
        bool rotacionActiva = Input.GetKey(KeyCode.R);   // Rotación (presionar 'R')
        bool escaladoActivo = Input.GetKey(KeyCode.E);   // Escalado (presionar 'E')

        // 1. Traslación: Orbita alrededor de la Tierra y sigue su movimiento
        if (traslacionActiva && tierra != null)
        {
            float angulo = Time.time * velocidadOrbita;
            Vector3 orbita = new Vector3(Mathf.Cos(angulo), 0, Mathf.Sin(angulo)) * distanciaALaTierra;
            transform.position = tierra.position + orbita;
        }

        // 2. Rotación: Rotar sobre su propio eje
        if (rotacionActiva)
        {
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
        }

        // 3. Escalado: Cambiar el tamaño de la Luna
        if (escaladoActivo)
        {
            tiempoEscalado += Time.deltaTime * velocidadEscalado;
            float escala = Mathf.Lerp(escalaMinima, escalaMaxima, Mathf.PingPong(tiempoEscalado, 1));
            transform.localScale = new Vector3(escala, escala, escala);
        }
    }
}
