using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 360f;

    private float _distanceSqrd;
    public float baseOrbitSpeed = 5f;
    public float currentOrbitSpeed;
    private Vector3 playerPos;

    private Vector3 _offsetFromPlayer;
    private float _currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        _offsetFromPlayer = transform.position - player.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // face player
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);

            playerPos = player.position;
            _distanceSqrd = (transform.position - playerPos).sqrMagnitude;
            currentOrbitSpeed = _distanceSqrd * baseOrbitSpeed;

            _currentAngle += currentOrbitSpeed * Time.deltaTime;
            Quaternion orbitRotation = Quaternion.Euler(0f, 0f, _currentAngle);
            Vector3 rotatedOffset = orbitRotation * _offsetFromPlayer;
            transform.position = player.position + rotatedOffset;
        }
        else
        {
            Debug.Log("player is null");
        }

        // speed
        //playerPos = player.position;
        //_distanceSqrd = (transform.position - playerPos).sqrMagnitude;
        //currentOrbitSpeed = _distanceSqrd * baseOrbitSpeed;

        //// orbit
        //_currentAngle += currentOrbitSpeed * Time.deltaTime;
        //Quaternion orbitRotation = Quaternion.Euler(0f, 0f, _currentAngle);
        //Vector3 rotatedOffset = rotationSpeed * _offsetFromPlayer;
        //transform.position = player.position + rotatedOffset;
    }
}
