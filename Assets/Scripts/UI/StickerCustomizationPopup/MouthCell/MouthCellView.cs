using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MouthCellView : MonoBehaviour
{
	[Header("Mouth Cell Elements")]
	[SerializeField] private MouthCellButtonView mouthCellButton;
	[SerializeField] private Text mouthNameLabel;
	[SerializeField] private Image mouthIconImage;
	[SerializeField] private GameObject selectedTick;

	private DisposeBag disposeBag = new DisposeBag();

	private MouthCellViewModel viewModel;

	public void SetViewModel(MouthCellViewModel viewModel)
	{
		disposeBag.ClearDisposables();

		this.viewModel = viewModel;

		disposeBag.AddDisposable(viewModel.MouthActiveObservable.Subscribe(selectedTick.SetActive));
		mouthCellButton.SetViewModel(viewModel.CreateAndSetUpMouthCellButtonViewModel());

		SetMouthCellLook();
	}

	private void SetMouthCellLook()
	{
		mouthNameLabel.text = viewModel.Name;
		mouthIconImage.sprite = viewModel.Icon;
	}
}
