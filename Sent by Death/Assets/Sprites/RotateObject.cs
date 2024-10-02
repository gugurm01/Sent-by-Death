using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Variável pública para definir a velocidade de rotação
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Exemplo: 100 no eixo Y

    // Update é chamado uma vez por frame
    void Update()
    {
        // Multiplica a velocidade de rotação pelo deltaTime para garantir que seja suave
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
