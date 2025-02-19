﻿using System;
using UnityEngine;

namespace MerJame.Spawning
{
    [Serializable]
    public class PointAnimationContainer
    {
        [field: SerializeField] public Transform Transfrom { get; private set; }
        [field: SerializeField] public PointAnimationData Data { get; private set; }
    }
}