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
    public List<SpawnSettings> spawnSettings; // Doðma ayarlarýný tutan liste

    private int currentDirection; // Geçerli doðma yönü
    private int currentSpawnCount; // Geçerli doðma adedi
    private float currentSpawnChance; // Geçerli doðma þansý

    private bool roomCompleted; // Oda tamamlama durumu

    private void Start()
    {
        // Rasgele doðma yönu seçimi yap
        currentDirection = Random.Range(0, spawnSettings.Count);

        // Geçerli doðma ayarlarýný güncelle
        UpdateCurrentSpawnSettings();

        // Ýlerleme iþlemini baþlat
        StartCoroutine(Progress());
    }

    private void UpdateCurrentSpawnSettings()
    {
        // Geçerli doðma ayarlarýný güncelle
        SpawnSettings settings = spawnSettings[currentDirection];
        currentSpawnCount = settings.spawnCount;
        currentSpawnChance = settings.spawnChance;
    }

    private IEnumerator Progress()
    {
        // Ýlerleme iþlemi
        while (!roomCompleted)
        {
            // Ýlerleme komutu
            // Örneðin, bir tuþa basýldýðýnda ilerlemeyi tetikleyebilirsiniz.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Doðma iþlemini gerçekleþtir
                Spawn();

                // Doðma adedini azalt
                currentSpawnCount--;

                // Oda tamamlama koþulunu kontrol et
                if (currentSpawnCount <= 0)
                {
                    roomCompleted = true;
                    // Oda tamamlandýktan sonra yapýlacak iþlemleri buraya ekleyebilirsiniz.
                }
            }

            yield return null;
        }
    }

    private void Spawn()
    {
        // Doðma iþlemini gerçekleþtir
        // Geçerli doðma yönu ve ayarlarýný kullanabilirsiniz
    }
}
