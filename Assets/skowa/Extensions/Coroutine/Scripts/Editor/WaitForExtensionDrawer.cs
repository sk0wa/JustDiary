namespace skowa.Extensions.Coroutine
{
    using UnityEngine;
    using UnityEditor;

    /// <summary>
    /// Настройка отрисовки полей в эдиторе для класса WaitForExtension
    /// </summary>
    [CustomPropertyDrawer(typeof(WaitForExtension))]
    public class WaitForExtensionDrawer : PropertyDrawer
    {
        protected string field_WaitType = "WaitType";
        protected string field_WaitSeconds = "WaitSeconds";

        protected SerializedProperty property_WaitType = default;
        protected SerializedProperty property_WaitSeconds = default;

        protected Rect rectHeader = default;
        protected Rect rectProperty = default;

        protected float heightLine = 0f;
        protected float heightSpace = 0f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            heightLine = EditorGUIUtility.singleLineHeight;
            heightSpace = EditorGUIUtility.standardVerticalSpacing;

            if (!property.isExpanded)
            {
                return heightLine;
            }

            property_WaitType = property.FindPropertyRelative(field_WaitType);

            // NOTE: Количество строк = заголовок + WaitType + (опционально)WaitSeconds
            int _lines = 1 + 1 + (WaitSeconds((WaitForType)property_WaitType.enumValueIndex) ? 1 : 0);

            return _lines * heightLine + (_lines - 1) * heightSpace;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            rectHeader = new Rect(position.x, position.y, position.width, heightLine);
            property.isExpanded = EditorGUI.Foldout(rectHeader, property.isExpanded, label, true);

            if (property.isExpanded)
            {
                EditorGUI.indentLevel++;

                rectProperty = new Rect(position.x, position.y + heightLine + heightSpace, position.width, heightLine);

                // NOTE: Отрисовка свойства WaitType
                property_WaitType = property.FindPropertyRelative(field_WaitType);
                EditorGUI.PropertyField(rectProperty, property_WaitType);

                // NOTE: Отрисовка свойства WaitSeconds
                property_WaitSeconds = property.FindPropertyRelative(field_WaitSeconds);
                if (WaitSeconds((WaitForType)property_WaitType.enumValueIndex))
                {
                    rectProperty.y += heightLine + heightSpace;
                    EditorGUI.PropertyField(rectProperty, property_WaitSeconds);
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }

        protected virtual bool WaitSeconds(WaitForType _type)
        {
            return _type == WaitForType.Seconds || _type == WaitForType.SecondsRealtime;
        }
    }
}
