using Mirror;
using UnityEngine;

namespace ProjectMER.Features;

public static class HczClutterSpawner
{
	private static readonly Dictionary<int, uint> PrefabIds = new()
	{
		{ 7, 38976586 },
		{ 8, 1687661105 },
		{ 9, 147203050 },
		{ 10, 3999209566 },
		{ 12, 1102032353 },
		{ 13, 2490430134 },
		{ 14, 2673083832 },
		{ 15, 2536312960 }
	};

	public static bool TryGetPrefab(int clutterType, out GameObject prefab)
	{
		prefab = null!;

		if (!PrefabIds.TryGetValue(clutterType, out uint assetId))
			return false;

		if (!NetworkClient.prefabs.TryGetValue(assetId, out prefab) || prefab == null)
			return false;

		return true;
	}

	public static GameObject? Create(int clutterType)
	{
		if (!TryGetPrefab(clutterType, out GameObject prefab))
			return null;

		return GameObject.Instantiate(prefab);
	}
}
