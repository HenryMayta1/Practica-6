using UnityEngine;

public class Tierra : MonoBehaviour
{
    public Transform sol; // Referencia al Sol (punto central)
    public float velocidadOrbita = 20f; // Velocidad de órbita de la Tierra
    public float distanciaAlSol = 5f; // Distancia de la Tierra al Sol
    public float velocidadRotacion = 30f; // Velocidad de rotación de la Tierra
    public float velocidadEscalado = 0.3f; // Velocidad de cambio de escala
    public float escalaMinima = 0.9f; // Escala mínima de la Tierra
    public float escalaMaxima = 1.1f; // Escala máxima de la Tierra

    private float tiempoEscalado = 0f;

    void Update()
    {
        // Control mediante teclado
        bool traslacionActiva = Input.GetKey(KeyCode.T); // Traslación (presionar 'T')
        bool rotacionActiva = Input.GetKey(KeyCode.R);   // Rotación (presionar 'R')
        bool escaladoActivo = Input.GetKey(KeyCode.E);   // Escalado (presionar 'E')

        // 1. Traslación: Orbita alrededor del Sol
        if (traslacionActiva && sol != null)
        {
            float angulo = Time.time * velocidadOrbita;
            Vector3 orbita = new Vector3(Mathf.Cos(angulo), 0, Mathf.Sin(angulo)) * distanciaAlSol;
            transform.position = sol.position + orbita;
        }

        // 2. Rotación: Rotar sobre su propio eje
        if (rotacionActiva)
        {
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
        }

        // 3. Escalado: Cambiar el tamaño de la Tierra
        if (escaladoActivo)
        {
            tiempoEscalado += Time.deltaTime * velocidadEscalado;
            float escala = Mathf.Lerp(escalaMinima, escalaMaxima, Mathf.PingPong(tiempoEscalado, 1));
            transform.localScale = new Vector3(escala, escala, escala);
        }
    }
}
