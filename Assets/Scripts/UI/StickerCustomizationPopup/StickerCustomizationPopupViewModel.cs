using UnityEngine;
using UniRx;

public class StickerCustomizationPopupViewModel
{
	public int MouthsCount {  get { return stickerCustomizationPopupModel.MouthsDataCount; } }

	public IObservable<string> SelectedMouthName { get { return selectedMouthModel.Select(x => x.Name); } }
	public IObservable<Sprite> SelectedMouthIcon { get { return selectedMouthModel.Select(x => cachedResourcesLoader.LoadSprite(x.IconPath)); } }

	private BehaviorSubject<MouthCellModel> selectedMouthModel;
	private CachedResourcesLoader cachedResourcesLoader;

    private StickerCustomizationPopupModel stickerCustomizationPopupModel;

	public StickerCustomizationPopupViewModel(StickerCustomizationPopupModel stickerCustomizationPopupModel, CachedResourcesLoader cachedResourcesLoader, int selectedMouthId)
    {
		selectedMouthModel = new BehaviorSubject<MouthCellModel>(stickerCustomizationPopupModel.GetDataWithIndex(selectedMouthId));
        this.stickerCustomizationPopupModel = stickerCustomizationPopupModel;
		this.cachedResourcesLoader = cachedResourcesLoader;
	}

    public MouthCellViewModel CreateAndSetUpMouthCellViewModel(int mouthIndex)
    {
		MouthCellModel model = stickerCustomizationPopupModel.GetDataWithIndex(mouthIndex);
		MouthCellViewModel mouthCellViewModel = new MouthCellViewModel(model, cachedResourcesLoader);
		mouthCellViewModel.SelectionIntent.Subscribe(_ => selectedMouthModel.OnNext(model));
		selectedMouthModel.Select(x => x.Id == mouthIndex).Subscribe(mouthCellViewModel.MouthActiveObserver);

		return mouthCellViewModel;
    }
}
