using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemHandler : MonoBehaviour
{
    public List<Transform> gemPositions;
    public Transform initialGemTransform;
    public int gems;
    public TextMeshProUGUI gemCounter;
    public GameObject destructionEffect;
    public GameObject gemPrefab;

    private void Start()
    {
        Instantiate(gemPrefab, initialGemTransform.position, initialGemTransform.rotation);
        gemCounter.text = $"Gems: {gems}";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Gem>() == null) return;

        var gem = other.gameObject;

        Destroy(gem);

        var localDestructionEffect = Instantiate(destructionEffect, gem.transform.position, gem.transform.rotation);
        Destroy(localDestructionEffect);

        AddGems();

        GemReached();
    }

    private void GemReached()
    {
        var currentGemTransform = gemPositions[Random.Range(0, gemPositions.Count - 1)];

        Instantiate(gemPrefab, currentGemTransform.position, currentGemTransform.rotation);
    }

    private void AddGems(int numberOfGems = 1)
    {
        gems += numberOfGems;
        gemCounter.text = $"Gems: {gems}";
    }
}