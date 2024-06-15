using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverPassaro : MonoBehaviour
{
    public Transform[] waypoints;      // Array de waypoints definidos diretamente
    public float speed = 3.0f;         // Velocidade do pássaro
    private int currentWaypointIndex;  // Índice do waypoint atual

    public GameObject ovoPrefab;       // Prefab do ovo a ser lançado como obstáculo
    public float intervaloDeLancamento = 3.0f; // Intervalo de tempo entre lançamentos de obstáculos
    private float tempoUltimoLancamento; // Tempo do último lançamento de obstáculo

    void Start()
    {
        currentWaypointIndex = 0; // Começa do primeiro waypoint
        tempoUltimoLancamento = Time.time; // Inicializa o tempo do último lançamento
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning("Nenhum waypoint definido no script para o pássaro mover-se.");
            return;
        }

        // Mover o pássaro em direção ao waypoint atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Verificar se é hora de lançar um obstáculo
        if (Time.time - tempoUltimoLancamento > intervaloDeLancamento)
        {
            LancaObstaculo();
            tempoUltimoLancamento = Time.time; // Atualiza o tempo do último lançamento
        }

        // Verificar se o pássaro alcançou o waypoint atual
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            currentWaypointIndex++; // Avança para o próximo waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Reinicia a partir do primeiro waypoint ao alcançar o último
            }
        }
    }

    void LancaObstaculo()
    {
        if (ovoPrefab != null)
        {
            // Instancia o componente "ovo" na posição do pássaro
            GameObject ovoInstanciado = Instantiate(ovoPrefab, transform.position, Quaternion.identity);
            ovoInstanciado.name = "OvoInstanciado"; // Opcional: renomeia o objeto instanciado se necessário
        }
    }
}
