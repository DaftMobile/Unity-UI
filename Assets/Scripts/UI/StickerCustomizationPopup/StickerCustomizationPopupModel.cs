using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class StickerCustomizationPopupModel
{
	public int MouthsDataCount { get { return mouthsData.Count; } }

    [SerializeField] private List<MouthCellModel> mouthsData;

	public StickerCustomizationPopupModel(List<MouthCellModel> mouthsData)
	{
		this.mouthsData = mouthsData;
	}

	public MouthCellModel GetDataWithIndex(int index)
	{
		return mouthsData[index];
	}

	public MouthCellModel GetDataWithPredicate(Predicate<MouthCellModel> predicate)
	{
		return mouthsData.Find(predicate);
	}
}
