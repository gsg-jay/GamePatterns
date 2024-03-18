using UnityEngine;

public class ComicPanelController : MonoBehaviour
{
    public GameObject[] comicPanels; // Array of comic panel GameObjects
    private int currentPanelIndex = 0; // Index of the current panel

    void Start()
    {
        // Hide all comic panels except the first one
        for (int i = 1; i < comicPanels.Length; i++)
        {
            comicPanels[i].SetActive(false);
        }
    }

    void Update()
    {
        // Check for input to reveal the next comic panel
        if (Input.GetButtonDown("buttonSouth") && currentPanelIndex < comicPanels.Length - 1)
        {
            // Hide the current panel
            comicPanels[currentPanelIndex].SetActive(false);

            // Move to the next panel
            currentPanelIndex++;

            // Show the next panel
            comicPanels[currentPanelIndex].SetActive(true);
        }
    }
}
