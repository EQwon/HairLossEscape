using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class WeaponDelay
{
    public float pre;
    public float attack;
    public float post;
}

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private WeaponDelay delay;
    [SerializeField] private int damage = 10;
    [SerializeField] private bool canAttack = true;

    private bool doingAttack = false;
    private GameObject myTarget;

    private void Update()
    {
        if (doingAttack)
        {
            DoAttack();
        }
    }

    public void DoAttack()
    {
        if (myTarget)
            myTarget.GetComponent<HairAI>().GetDamage(damage);
    }

    public void TryAttack(GameObject target)
    {
        if (canAttack)
        {
            myTarget = target;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        if (canAttack == false) yield break;

        canAttack = false;

        yield return new WaitForSeconds(delay.pre);

        doingAttack = true;

        yield return new WaitForSeconds(delay.attack);

        doingAttack = false;

        yield return new WaitForSeconds(delay.post);

        canAttack = true;
    }
}

[CustomPropertyDrawer(typeof(WeaponDelay))]
public class DelayDrawerUIE : PropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        float rectWidth = (position.width - 10) / 3;
        var preRect = new Rect(position.x, position.y, rectWidth, position.height);
        var attackRect = new Rect(position.x + rectWidth + 5, position.y, rectWidth, position.height);
        var postRect = new Rect(position.x + rectWidth * 2 + 10, position.y, rectWidth, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(preRect, property.FindPropertyRelative("pre"), GUIContent.none);
        EditorGUI.PropertyField(attackRect, property.FindPropertyRelative("attack"), GUIContent.none);
        EditorGUI.PropertyField(postRect, property.FindPropertyRelative("post"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
