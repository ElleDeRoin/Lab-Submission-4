using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public bool gameOver = false;

    public int meteorCount = 0;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            CancelInvoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }

        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }

    float minXDistanceFromPlayer()
    {
        float minDistance = _player.transform.position.x + 2;
        return minDistance;
    }

    float minYDistanceFromPlayer()
    {
        float minDistance = _player.transform.position.y + 2;
        return minDistance;
    }

    void SpawnMeteor()
    {
        float randomX = Random.Range(-8, 8) + minXDistanceFromPlayer();
        float randomY = Random.Range(-6, 6) + minYDistanceFromPlayer();
        Instantiate(meteorPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 5f, 0), Quaternion.identity);
    }
}
