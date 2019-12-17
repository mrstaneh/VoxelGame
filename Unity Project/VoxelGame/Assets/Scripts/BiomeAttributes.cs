using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BiomeAttributes", menuName = "VoxelGame : Biome Attribute")]
public class BiomeAttributes : ScriptableObject
{
    public string biomeName;

    public int solidGroundHeight;
    public int terrainHeight;
    public float terrainScale;
    public int terrainIterations;
    public float persistence;

    public Lode[] lodes;
}

[System.Serializable]
public class Lode
{
    public bool enabled;
    public string nodeName;
    public byte blockId;
    public int minHeight;
    public int maxHeight;
    public float scale;
    public float threshold;
    public float noiseOffset;
    public int iterations;
    public float persistence;
}
