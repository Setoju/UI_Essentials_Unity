using UnityEngine;

public class SettingsMenuTransition : MonoBehaviour
{
    public Transform settingsPanel;
    public Vector3 shownPosition;
    public Vector3 hiddenPosition;
    public float transitionDuration = 0.5f;

    private bool isVisible = false;
    public void ToggleSettingsMenu()
    {
        StopAllCoroutines();
        StartCoroutine(SmoothMove(settingsPanel, isVisible ? hiddenPosition : shownPosition, transitionDuration));
        isVisible = !isVisible;
    }

    private System.Collections.IEnumerator SmoothMove(Transform target, Vector3 toPosition, float duration)
    {
        Vector3 start = target.position;
        float elapsed = 0;

        while (elapsed < duration)
        {
            target.position = Vector3.Lerp(start, toPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        target.position = toPosition;
    }
}
