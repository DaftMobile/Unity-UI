using System.Collections.Generic;
using System;

public class DisposeBag
{
	private List<IDisposable> disposables;

	public DisposeBag()
	{
		disposables = new List<IDisposable>();
	}

	~DisposeBag()
	{
		ClearDisposables();
	}

	public void AddDisposable(IDisposable disposable)
	{
		disposables.Add(disposable);
	}

	public void ClearDisposables()
	{
		disposables.ForEach(disposable => disposable.Dispose());
		disposables.Clear();
	}
}
