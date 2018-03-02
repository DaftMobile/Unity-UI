using UnityEngine;

public class ResourcesLoader
{
	public virtual Sprite LoadSprite(string spritePath)
	{
		return Resources.Load<Sprite>(spritePath);
	}
}
