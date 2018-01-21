using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NCCUW5MonsterSpawn : MonoBehaviour {
    public GameObject _MonsterPrefab;
    public List<Transform> _SpawnPoints;
    public GameObject InitFollowTarget;

    public float _SpawnTime = 10;
    private float _SpwanCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _SpwanCounter += Time.deltaTime;

        if (_SpwanCounter >= _SpawnTime)
        {
            _SpwanCounter = 0;

            GameObject NewMonster = GameObject.Instantiate(_MonsterPrefab);
            NewMonster.transform.position = _SpawnPoints[Random.Range(0, _SpawnPoints.Count)].position;
        }
	}
}
