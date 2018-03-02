using UniRx;
using UnityEngine;

public class MouthCellViewModel
{
	public string Name {  get { return mouthCellModel.Name; } }
	public Sprite Icon { get { return cachedResourcesLoader.LoadSprite(mouthCellModel.IconPath); } }

	public IObservable<bool> MouthActiveObservable { get { return mouthActive.AsObservable(); } } 
	public IObserver<bool> MouthActiveObserver { get { return mouthActive; } }
	private BehaviorSubject<bool> mouthActive = new BehaviorSubject<bool>(false);

	private Subject<Unit> selectionIntent = new Subject<Unit>();
	public IObservable<Unit> SelectionIntent {  get { return selectionIntent.AsObservable(); } }

	private CachedResourcesLoader cachedResourcesLoader;
    private MouthCellModel mouthCellModel;
	private MouthCellButtonViewModel mouthCellButtonViewModel;

	public MouthCellViewModel(MouthCellModel mouthCellModel, CachedResourcesLoader cachedResourcesLoader)
    {
        this.mouthCellModel = mouthCellModel;
		this.cachedResourcesLoader = cachedResourcesLoader;
    }

    public MouthCellButtonViewModel CreateAndSetUpMouthCellButtonViewModel()
    {
		if (mouthCellButtonViewModel != null)
			return mouthCellButtonViewModel;
		
		mouthCellButtonViewModel = new MouthCellButtonViewModel();
		mouthCellButtonViewModel.ButtonClickStream.Subscribe(selectionIntent.OnNext);

		return mouthCellButtonViewModel;
    }
}
