namespace skowa.Data.PlayerPrefs
{
    using UnityEngine;
    using UnityEditor;

    using skowa.EDebug;

    /// <summary>
    /// Надстройка редактора для PlayerPrefs
    /// </summary>
    public class PlayerPrefsEditor : EditorWindow
    {
        private static PlayerPrefsEditor _window = default;

        private string _key = "key";

        [MenuItem("skowa/PlayerPrefs/Clear All")]
        private static void ClearAll()
        {
            PlayerPrefsHelper.ClearAll();

            EDebug.Log(nameof(PlayerPrefsEditor), $"Все ключи PlayerPrefs были очищены.");
        }

        [MenuItem("skowa/PlayerPrefs/Clear Key")]
        private static void ClearKeyWindow()
        {
            _window = CreateInstance<PlayerPrefsEditor>();

            _window.position = new Rect(Screen.width / 2, Screen.height / 2, 500, 100);
            _window.ShowUtility();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.LabelField("Key to clear:");

            GUILayout.Space(10);
            _key = EditorGUILayout.TextField("", _key);

            GUILayout.Space(10);
            if (GUILayout.Button("Clear key"))
            {
                OnClearKey();
            }
        }

        private void OnClearKey()
        {
            PlayerPrefsHelper.ClearKey(_key);

            EDebug.Log(nameof(PlayerPrefsEditor), $"Ключ '{_key}' в PlayerPrefs был очищен.");
        }
    }
}
