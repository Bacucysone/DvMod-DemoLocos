using System.Collections.Generic;
using UnityEngine;

namespace DvMod.DemoLocos;

public class SpawnPoints {
    public readonly struct SpawnPoint(string n, float x, float y, float z)
    {
        public string Name { get; } = n;
        public Vector3 Position { get; } = new Vector3(x, y, z);
    }
    private static readonly List<SpawnPoint> allSpawnPoints = [
		new SpawnPoint("CP Shed / A6S", 2216.55f, 145.119f, 9034.95f),
		new SpawnPoint("CME green building", 15632.13f, 204.28f, 11162.54f),
		new SpawnPoint("CP Shed / A4S", 1852.979f, 145.119f, 9329.24f),
		new SpawnPoint("CP / A6S North", 2160.51f, 145.119f, 9042.45f),
		new SpawnPoint("CMS / A2L", 8514.341f, 156.3079f, 3552.408f),
		new SpawnPoint("SM Service Shed", 8038.72f, 131.86f, 7127.34f),
		new SpawnPoint("GF Loco Spawn Shed right", 13087.57f, 140.093f, 11039.52f),
		new SpawnPoint("IME / A1L", 15170.11f, 248.2943f, 15437.31f),
		new SpawnPoint("HB Loco Spawn", 12923.64f, 113.08f, 3639.59f),
		new SpawnPoint("HB D yard Shed", 13518.51f, 112.97f, 3495.79f),
		new SpawnPoint("IMW / B8L North", 2113.4f, 133.69f, 13433.45f),
		new SpawnPoint("GF /A3S", 13176.75f, 140.093f, 11059.94f),
		new SpawnPoint("CP / A6S South", 2253.34f, 145.119f, 8853.61f),
		new SpawnPoint("FRS / B1L", 5325.05f, 174.74f, 3785.03f),
		new SpawnPoint("SM / A6I", 7925.49f, 131.86f, 7188.08f),
		new SpawnPoint("HB Shop", 13427.02f, 112.97f, 3622.94f),
		new SpawnPoint("FF B yard", 9521.979f, 119.2f, 13465.91f),
		new SpawnPoint("GF South exit", 12582.31f, 110.51f, 10648.67f),
		new SpawnPoint("CW Plaza B yard", 1862.01f, 122.323f, 5450.5f),
		new SpawnPoint("HB Roundhouse", 12788.12f, 113.08f, 3601.81f),
		new SpawnPoint("OWC / A1L", 4929.6f, 122.96f, 6324.2f),
		new SpawnPoint("CP Shed / A4S", 1856.359f, 145.119f, 9288.9f),
		new SpawnPoint("SM / A4S", 7924.46f, 131.86f, 7112.42f),
		new SpawnPoint("SW / C1O Shed", 1309.609f, 147.27f, 2193.77f),
		new SpawnPoint("GF / C1SP", 13021.11f, 140.093f, 11083.36f),
		new SpawnPoint("HB / F4SP", 13380.01f, 112.97f, 3542.92f),
		new SpawnPoint("FF C yard between buildings", 9400.66f, 120.8f, 13476.36f),
		new SpawnPoint("GF Loco Spawn Shed left", 13066.43f, 140.093f, 11023.47f),
		new SpawnPoint("MF Roundhouse East", 2212.609f, 159.193f, 10615.77f),
		new SpawnPoint("OWN Service Shed", 11535.71f, 122.24f, 11628.09f),
		new SpawnPoint("CW / C6L", 1823.676f, 122.213f, 5664.788f),
		new SpawnPoint("CS / A1LP", 10017.58f, 134.73f, 1378.58f),
		new SpawnPoint("OR / A4S", 6552.149f, 143.92f, 11473.41f),
		new SpawnPoint("CW/OWC middle triangle", 3320.215f, 112.935f, 5688.702f),
		new SpawnPoint("CW NE of B yard", 1924.729f, 122.213f, 5567.21f),
		new SpawnPoint("SM / A3S", 7917.89f, 131.73f, 7247.16f),
		new SpawnPoint("FM / A3L", 6007.85f, 123.89f, 6639.3f),
		new SpawnPoint("IMW / B8L South", 2193.83f, 133.69f, 13333.51f),
		new SpawnPoint("OR / A6S", 6568.97f, 143.92f, 11452.62f),
		new SpawnPoint("FF / D1L", 9369.199f, 120.78f, 13418.32f),
		new SpawnPoint("FF Service shed", 9327.21f, 119.2f, 13358.35f),
		new SpawnPoint("CMS brick building", 8498.551f, 156.3079f, 3233.249f),
		new SpawnPoint("FF Turntable", 9381.989f, 119.2f, 13330.21f),
		new SpawnPoint("CS Museum", 10274.72f, 134.73f, 1443.29f),
		new SpawnPoint("IMW SE of Office", 2185.58f, 133.69f, 13195.64f),
		new SpawnPoint("CP / A1S", 2004.42f, 145.119f, 8912.18f),
		new SpawnPoint("HB D yard shed", 13279.06f, 112.97f, 3437.66f),
		new SpawnPoint("SM W/ A7L 1", 7848.25f, 131.73f, 7213.14f),
		new SpawnPoint("HB F yard East", 13764.49f, 112.97f, 3556.25f),
		new SpawnPoint("OR / B7S", 6394.12f, 143.92f, 11365.58f),
		new SpawnPoint("OR / A3S", 6452.59f, 143.92f, 11230.71f),
		new SpawnPoint("SM / A7L 2", 7863.1f, 131.73f, 7208.11f),
		new SpawnPoint("MF Roundhouse East 2", 2278.24f, 159.193f, 10676.87f),
		new SpawnPoint("FRC C yard North", 5759.84f, 144.91f, 9003.39f),
		new SpawnPoint("CW East exit", 2243.05f, 111.01f, 5699.65f),
		new SpawnPoint("CME Coal Mine", 15552.81f, 181.5f, 11033.37f),
		new SpawnPoint("MF Roundhouse West", 2267.709f, 159.193f, 10657.35f)
	];
	public static string GetClosest(Vector3 position) {
        string ret = "ERROR";
        float minVal = float.PositiveInfinity;
        foreach(SpawnPoint item in allSpawnPoints) {
            if (Vector3.Distance(position, item.Position) < minVal) {
                ret = item.Name;
                minVal = Vector3.Distance(position, item.Position);
            }
        }
        return ret;
    }
    public static string GetStation(Vector3 position) {
        return GetClosest(position).Split(' ')[0];
    }
}