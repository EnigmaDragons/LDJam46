using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Demons;
using UnityEngine;

public class HumiliationDemon : MonoBehaviour
{
    [SerializeField] private DemonState demonState;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float startingSpawnPercentage;
    [SerializeField] private float spawnPercentageBasedOnPercent;
    [SerializeField] private HumiliationImp impPrefab;

    private Dictionary<Transform, HumiliationImp> _imps = new Dictionary<Transform, HumiliationImp>();

    private void Awake()
    {
        Message.Subscribe<ActivateDemon>(x =>
        {
            if (x.Demon == DemonName.Humiliation)
            {
                demonState.Activate();
            }
        }, this);
    }

    private void Update()
    {
        if (!demonState.IsActive)
            return;
        var spawnPercent = demonState.ProgressPercent >= 1
            ? spawnPoints.Length
            : startingSpawnPercentage + demonState.ProgressPercent * spawnPercentageBasedOnPercent;
        var spawns = (int)Math.Round(spawnPoints.Length * spawnPercent);
        if (_imps.Count < spawns)
        {
            var points = spawnPoints.Where(x => !_imps.ContainsKey(x)).OrderBy(x => Rng.Dbl()).ToArray();
            for (var i = 0; i < spawns - _imps.Count; i++)
            {
                _imps[points[i]] = Instantiate(impPrefab, points[i].position, Quaternion.identity, gameObject.transform);
            }
        }
        else if (_imps.Count > spawns)
        {
            var imps = _imps.OrderBy(x => Rng.Dbl()).ToArray();
            for (var i = 0; i < _imps.Count - spawns; i++)
            {
                imps[i].Value.IsDying = true;
                _imps.Remove(imps[i].Key);
            }
        }
    }
}