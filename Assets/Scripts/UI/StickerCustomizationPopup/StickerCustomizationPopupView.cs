using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class StickerCustomizationPopupView : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject mouthCellPrefab;

    [Header("Popup elements")]
    [SerializeField] private Image stickerMouth;
	[SerializeField] private Text mouthLabelName;
    [SerializeField] private Transform mouthCellsContainer;

	private DisposeBag disposeBag = new DisposeBag();
    private StickerCustomizationPopupViewModel viewModel;

    private void Awake()
    {
        string mouthsData = Resources.Load<TextAsset>("MouthsData").text;
        StickerCustomizationPopupModel stickerCustomizationPopupModel = JsonUtility.FromJson<StickerCustomizationPopupModel>(mouthsData);

		SetViewModel(new StickerCustomizationPopupViewModel(stickerCustomizationPopupModel, new CachedResourcesLoader(), stickerCustomizationPopupModel.GetDataWithIndex(0).Id));
    }

    public void SetViewModel(StickerCustomizationPopupViewModel viewModel)
    {
		disposeBag.ClearDisposables();
        this.viewModel = viewModel;

		disposeBag.AddDisposable(viewModel.SelectedMouthName.Subscribe(name => mouthLabelName.text = name));
		disposeBag.AddDisposable(viewModel.SelectedMouthIcon.Subscribe(icon => stickerMouth.sprite = icon));

		CreateNewMouthsGridWithData();
	}

    private void CreateNewMouthsGridWithData()
    {
		DestroyAlreadyLoadedCells();

		for (int i = 0; i < viewModel.MouthsCount; i++)
        {
            CreateMouthCell(i);
        }
    }

	private void DestroyAlreadyLoadedCells()
	{
		for (int i = 0; i < mouthCellsContainer.childCount; i++)
		{
			Destroy(mouthCellsContainer.GetChild(i).gameObject);
		}
	}

    private void CreateMouthCell(int mouthIndex)
    {
        GameObject mouthCell = Instantiate(mouthCellPrefab, Vector3.zero, Quaternion.identity, mouthCellsContainer);
		mouthCell.GetComponent<MouthCellView>().SetViewModel(viewModel.CreateAndSetUpMouthCellViewModel(mouthIndex));
    }
}
