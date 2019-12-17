using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator
{
    public static float Get2DPerlin(Vector2 position, float offset, float scale, int seed, int iterations, float persistence)
    {
        float startValue = 0f;
        float frequency = 1f;
        float amplitude = 1f;
        float maxValue = 0f;
        for (int i = 0; i < iterations; i++)
        {
            startValue += Mathf.PerlinNoise((seed + (position.x + 0.1f) / VoxelData.ChunkWidth * scale + offset) * frequency, (seed + (position.y + 0.1f) / VoxelData.ChunkWidth * scale + offset) * frequency);

            maxValue += amplitude;
            amplitude *= persistence;
            frequency *= 2;
        }
        return startValue / iterations;
    }

    public static float Get3DPerlinFloat(Vector3 position, float offset, float scale, int seed) 
    {
        float x = (position.x + offset + 0.1f) * scale + seed;
        float y = (position.y + offset + 0.1f) * scale + seed;
        float z = (position.z + offset + 0.1f) * scale + seed;

        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);

        float BA = Mathf.PerlinNoise(y, x);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        return (AB + BC + AC + BA + CB + CA) / 6f;
    }

    public static float Get3DPerlinFloatIterations(Vector3 position, float offset, float scale, int seed, int iterations, float persistence) 
    {
        float startValue = 0f;
        float frequency = 1f;
        float amplitude = 1f;
        float maxValue = 0f;
        for (int i = 0; i < iterations; i++) 
        {
            startValue += Get3DPerlinFloat(position, offset, scale, seed);

            maxValue += amplitude;
            amplitude *= persistence;
            frequency *= 2;
        }
        return startValue / iterations;
    }

    public static bool Get3DPerlin(Vector3 position, float offset, float scale, float threshold, int seed, int iterations, float persistence) 
    {
        if (Get3DPerlinFloatIterations(position, offset, scale, seed, iterations, persistence) > threshold)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
