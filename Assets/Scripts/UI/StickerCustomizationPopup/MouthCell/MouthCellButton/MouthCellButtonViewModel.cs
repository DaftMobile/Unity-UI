using UniRx;

public class MouthCellButtonViewModel 
{
	public IObservable<Unit> ButtonClickStream { get { return buttonClick.AsObservable(); } }
	public IObserver<Unit> ButtonClickObserver { get { return buttonClick; } }

	private Subject<Unit> buttonClick = new Subject<Unit>();
}
