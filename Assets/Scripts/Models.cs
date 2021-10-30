using System;
using System.Collections.Generic;
using UnityEngine;

public static class Models
{
    [Serializable]
    public class PlayerSettingsModel
    {
        [Header("View Settings")]
        [SerializeField] public float mouseSensitivity = 2f;

        public bool viewXInverted;
        public bool viewYInverted;
    }
}
