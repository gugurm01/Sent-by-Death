using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Vari�vel p�blica para definir a velocidade de rota��o
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Exemplo: 100 no eixo Y

    // Update � chamado uma vez por frame
    void Update()
    {
        // Multiplica a velocidade de rota��o pelo deltaTime para garantir que seja suave
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
