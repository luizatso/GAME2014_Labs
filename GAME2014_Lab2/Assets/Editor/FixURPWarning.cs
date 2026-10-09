using UnityEditor;
using UnityEngine;

public static class FixURPWarning
{
    [MenuItem("Tools/Fix URP Missing References")]
    private static void Fix()
    {
        Object asset = Selection.activeObject;

        if (asset == null ||
            asset.GetType().Name != "UniversalRenderPipelineGlobalSettings")
        {
            Debug.LogWarning(
                "Select UniversalRenderPipelineGlobalSettings in the Project window first.");
            return;
        }

        Undo.RecordObject(asset, "Clear Missing URP References");

        bool changed =
            UnityEditor.SerializationUtility
                .ClearAllManagedReferencesWithMissingTypes(asset);

        if (changed)
        {
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
            Debug.Log("Removed missing references from URP Global Settings.");
        }
        else
        {
            Debug.Log("No missing references found on the selected asset.");
        }
    }
}