using UnityEngine;

public class ScriptUtility : MonoBehaviour
{
    public void SetScriptsActive(GameObject targetObject, bool isActive)
    {
        MonoBehaviour[] scripts = targetObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = isActive;
        }
    }
}