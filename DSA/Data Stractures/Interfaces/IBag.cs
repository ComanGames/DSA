using System.Collections.Generic;

namespace DSA.Interfaces
{
	public interface IBag<T>: IEnumerator<T>
	{
		void Add(T item);
		 int Count { get; }
	}
}