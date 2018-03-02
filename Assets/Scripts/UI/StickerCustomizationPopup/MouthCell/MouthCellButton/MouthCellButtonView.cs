using UnityEngine;
using UnityEngine.UI;
using UniRx;

[RequireComponent(typeof(Button))]
public class MouthCellButtonView : MonoBehaviour
{
    private MouthCellButtonViewModel viewModel;
    private Button cellButton;

	private DisposeBag disposeBag = new DisposeBag();

    private void Awake()
    {
        cellButton = GetComponent<Button>();
    }

    public void SetViewModel(MouthCellButtonViewModel viewModel)
    {
		disposeBag.ClearDisposables();
        this.viewModel = viewModel;
		disposeBag.AddDisposable(cellButton.OnClickAsObservable().Subscribe(viewModel.ButtonClickObserver));
    }
}