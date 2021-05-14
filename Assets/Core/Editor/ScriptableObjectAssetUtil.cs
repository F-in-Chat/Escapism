using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    public static class ScriptableObjectAssetUtil
    {
        [MenuItem("Assets/Create/Asset from ScriptableObject", true)]
        private static bool CreateScriptableObjAsAssetValidator()
        {
            var activeObject = Selection.activeObject;

            // make sure it is a text asset
            if ((activeObject == null) || !(activeObject is TextAsset))
            {
                return false;
            }

            // make sure it is a persistant asset
            var assetPath = AssetDatabase.GetAssetPath(activeObject);
            if (assetPath == null)
            {
                return false;
            }

            // load the asset as a monoScript
            var monoScript = (MonoScript)AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
            if (monoScript == null)
            {
                return false;
            }

            // get the type and make sure it is a scriptable object
            var scriptType = monoScript.GetClass();
            if (scriptType == null || !scriptType.IsSubclassOf(typeof(ScriptableObject)))
            {
                return false;
            }

            return true;
        }

        [MenuItem("Assets/Create/Asset from ScriptableObject")]
        private static void CreateScriptableObjectAssetMenuCommand(MenuCommand command)
        {
            // we already validated this path, and know these calls are safe
            var activeObject = Selection.activeObject;
            var assetPath = AssetDatabase.GetAssetPath(activeObject);
            var script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
            CreateNewInstance(assetPath, script);
        }

        private static void CreateNewInstance(string assetPath, MonoScript script)
        {
            var scriptType = script.GetClass();
            var path = Path.Combine(Path.GetDirectoryName(assetPath) ?? string.Empty, scriptType.Name + ".asset");
            try
            {
                var inst = ScriptableObject.CreateInstance(scriptType);
                AssetDatabase.CreateAsset(inst, path);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        //[UnityEditor.Callbacks.DidReloadScripts]
        //private static void AutoCreateFunctionScripts()
        //{
        //    var guids = AssetDatabase.FindAssets("t: MonoScript");
        //    foreach(var guid in guids)
        //    {
        //        var assetPath = AssetDatabase.GUIDToAssetPath(guid);
        //        var script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
        //        if (script == null || script.GetClass() == null) continue;
        //        if (script.GetClass().IsSubclassOf(typeof(Function)))
        //        {
        //            var functionGuids = AssetDatabase.FindAssets($"t: {script.GetClass().Name}");
        //            if (functionGuids.Length == 0)
        //            {
        //                var functionPath = "Assets/Functions/Uncategorized/";
        //                CreateNewInstance(functionPath, script);
        //            }
        //        }
        //    }
        //}
    }
}