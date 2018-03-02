using System.Collections.Generic;
using UnityEngine;

public class CachedResourcesLoader : ResourcesLoader
{
	private Dictionary<string, object> resources = new Dictionary<string, object>();

	public override Sprite LoadSprite(string spritePath)
	{
		if (resources.ContainsKey(spritePath))
			return resources[spritePath] as Sprite;

		Sprite sprite = base.LoadSprite(spritePath);
		resources.Add(spritePath, sprite);
		return sprite;
	}
}
