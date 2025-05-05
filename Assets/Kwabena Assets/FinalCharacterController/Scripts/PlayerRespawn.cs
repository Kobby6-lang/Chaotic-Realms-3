using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint;
    private CharacterController characterController;
    private int deathCount = 0;
    public TextMeshProUGUI deathCounterText;

    private bool isRespawning = false;
    private float respawnCooldown = 1f; // Cooldown time in seconds

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (respawnPoint == null)
        {
            respawnPoint = transform;
        }

        UpdateDeathCounterUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard") && !isRespawning)
        {
            StartCoroutine(RespawnAndResetLevel());
        }
    }

    private IEnumerator RespawnAndResetLevel()
    {
        isRespawning = true;
        deathCount++;
        UpdateDeathCounterUI();

        characterController.enabled = false;
        transform.position = respawnPoint.position;
        characterController.enabled = true;

        Debug.Log($"Player has respawned. Death count: {deathCount}");

        yield return new WaitForSeconds(respawnCooldown);
        isRespawning = false;
    }

    private void UpdateDeathCounterUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = $"Deaths: {deathCount}";
        }
    }
}