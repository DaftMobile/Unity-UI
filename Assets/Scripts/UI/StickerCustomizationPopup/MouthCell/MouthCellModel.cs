using UnityEngine;
using System;

[Serializable]
public class MouthCellModel
{
	[SerializeField] private int id;
    public int Id { get { return id; } }

    [SerializeField] private string name;
    public string Name { get { return name; } }

    [SerializeField] private string iconPath;
    public string IconPath { get { return iconPath; } }

	public MouthCellModel(int id, string name, string iconPath)
	{
		this.id = id;
		this.name = name;
		this.iconPath = iconPath;
	}
}