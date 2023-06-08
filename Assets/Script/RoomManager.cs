using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnSettings
{
    public int direction;
    public int spawnCount;
    public float spawnChance;
}

public class RoomSpawnSettings : MonoBehaviour
{
    public List<SpawnSettings> spawnSettings; // Do�ma ayarlar�n� tutan liste

    private int currentDirection; // Ge�erli do�ma y�n�
    private int currentSpawnCount; // Ge�erli do�ma adedi
    private float currentSpawnChance; // Ge�erli do�ma �ans�

    private bool roomCompleted; // Oda tamamlama durumu

    private void Start()
    {
        // Rasgele do�ma y�nu se�imi yap
        currentDirection = Random.Range(0, spawnSettings.Count);

        // Ge�erli do�ma ayarlar�n� g�ncelle
        UpdateCurrentSpawnSettings();

        // �lerleme i�lemini ba�lat
        StartCoroutine(Progress());
    }

    private void UpdateCurrentSpawnSettings()
    {
        // Ge�erli do�ma ayarlar�n� g�ncelle
        SpawnSettings settings = spawnSettings[currentDirection];
        currentSpawnCount = settings.spawnCount;
        currentSpawnChance = settings.spawnChance;
    }

    private IEnumerator Progress()
    {
        // �lerleme i�lemi
        while (!roomCompleted)
        {
            // �lerleme komutu
            // �rne�in, bir tu�a bas�ld���nda ilerlemeyi tetikleyebilirsiniz.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Do�ma i�lemini ger�ekle�tir
                Spawn();

                // Do�ma adedini azalt
                currentSpawnCount--;

                // Oda tamamlama ko�ulunu kontrol et
                if (currentSpawnCount <= 0)
                {
                    roomCompleted = true;
                    // Oda tamamland�ktan sonra yap�lacak i�lemleri buraya ekleyebilirsiniz.
                }
            }

            yield return null;
        }
    }

    private void Spawn()
    {
        // Do�ma i�lemini ger�ekle�tir
        // Ge�erli do�ma y�nu ve ayarlar�n� kullanabilirsiniz
    }
}
