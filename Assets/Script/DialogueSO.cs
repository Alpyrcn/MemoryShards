using UnityEngine;
using UnityEngine.UI;

// Diyalog i�in gerekli verileri tutacak olan Scriptable Object
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/New Dialogue")]
public class DialogueSO : ScriptableObject
{
    // Konu�an karakterin ad�
    public string speakerName;

    // Diyalog metni
    [TextArea(3, 10)]
    public string[] dialogueLines;

    // Diyalog kutusunun pozisyonu
    public Vector2 boxPosition;
}

// Diyalog kutusu i�in gerekli olan UI elementlerinin kontrol�n� sa�layacak olan kod
public class DialogueBox : MonoBehaviour
{
    // UI elementleri
    public Text speakerNameText;
    public Text dialogueText;
    public RectTransform boxTransform;

    // Diyalog Scriptable Object'i
    public DialogueSO dialogue;

    // Diyalog kutusu olu�turuldu�unda �al��acak olan kod
    private void OnEnable()
    {
        // Diyalog verilerini UI elementlerine y�kle
        speakerNameText.text = dialogue.speakerName;
        dialogueText.text = dialogue.dialogueLines[0];
        boxTransform.anchoredPosition = dialogue.boxPosition;
    }
}
