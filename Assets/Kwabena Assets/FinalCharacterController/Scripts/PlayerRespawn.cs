using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerRespawn : MonoBehaviour
{
    public Transform[] respawnPoints; // All possible respawn points
    private List<Transform> visitedRespawnPoints = new List<Transform>(); // Tracks points visited
    private CharacterController characterController;
    private int deathCount = 0;
    public TextMeshProUGUI deathCounterText;

    private bool isRespawning = false;
    private float respawnCooldown = 1f; // Cooldown time in seconds

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (respawnPoints == null || respawnPoints.Length == 0)
        {
            Debug.LogError("No respawn points set!");
        }

        UpdateDeathCounterUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard") && !isRespawning)
        {
            StartCoroutine(RespawnAndResetLevel());
        }
        else if (other.CompareTag("RespawnPoint"))
        {
            RegisterRespawnPoint(other.transform);
        }
    }

    private IEnumerator RespawnAndResetLevel()
    {
        isRespawning = true;
        deathCount++;
        UpdateDeathCounterUI();

        Transform respawnLocation = FindEligibleRespawnPoint();

        characterController.enabled = false;
        transform.position = respawnLocation.position;
        characterController.enabled = true;

        Debug.Log($"Player respawned at {respawnLocation.position}. Death count: {deathCount}");

        yield return new WaitForSeconds(respawnCooldown);
        isRespawning = false;
    }

    private void RegisterRespawnPoint(Transform point)
    {
        if (!visitedRespawnPoints.Contains(point))
        {
            visitedRespawnPoints.Add(point);
            Debug.Log($"Respawn point {point.position} has been registered.");
        }
    }

    private Transform FindEligibleRespawnPoint()
    {
        if (visitedRespawnPoints.Count > 0)
        {
            return visitedRespawnPoints[visitedRespawnPoints.Count - 1]; // Last visited point
        }
        else
        {
            return respawnPoints[0]; // Default respawn location
        }
    }

    private void UpdateDeathCounterUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = $"Deaths: {deathCount}";
        }
    }
}