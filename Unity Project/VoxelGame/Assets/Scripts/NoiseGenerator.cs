using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator
{
    public static float Get2DPerlin(Vector2 position, float offset, float scale, int seed) 
    {
        return Mathf.PerlinNoise(seed + (position.x + 0.1f) / VoxelData.ChunkWidth * scale + offset, seed + (position.y + 0.1f) / VoxelData.ChunkWidth * scale + offset);
    }

    public static bool Get3DPerlin(Vector3 position, float offset, float scale, float threshhold, int seed) 
    {
        float x = (position.x + offset + 0.1f) * scale;
        float y = (position.y + offset + 0.1f) * scale;
        float z = (position.z + offset + 0.1f) * scale;

        float AB = Mathf.PerlinNoise(seed + x, seed +y);
        float BC = Mathf.PerlinNoise(seed + y, seed + z);
        float AC = Mathf.PerlinNoise(seed + x, seed + z);

        float BA = Mathf.PerlinNoise(seed + y, seed + x);
        float CB = Mathf.PerlinNoise(seed + z, seed + y);
        float CA = Mathf.PerlinNoise(seed + z, seed + x);

        if ((AB + BC + AC + BA + CB + CA) / 6f > threshhold)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
