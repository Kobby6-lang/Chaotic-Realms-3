using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int collectedBones = 0;
    private int totalBones;

    private void Awake()
    {
        // Singleton pattern to ensure one GameManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        totalBones = FindObjectsOfType<Bones>().Length;
        Debug.Log("Total bones in scene: " + totalBones);
    }

    public void CollectBone()
    {
        collectedBones++;
        Debug.Log("Collected bones: " + collectedBones + " / " + totalBones);

        if (collectedBones >= totalBones)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("All bones collected! Game Over!");
        SceneManager.LoadScene("GameOverScene");
    }

    public void ResetBones()
    {
        collectedBones = 0;
    }
}