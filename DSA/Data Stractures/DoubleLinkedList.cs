using System;
using System.Collections;
using System.Collections.Generic;
using DSA.Interfaces;

namespace DSA
{
	public class DoubleLinkedList<T>:ICollection<T>,IBag<T> where T:IComparable
	{
		protected class DoubleNode : SingleLinkedList<T>.Node
		{
			public DoubleNode(T value) : base(value)
			{
				Value = value;
			}
			internal DoubleNode Previous { get; set; }
			internal new DoubleNode Next { get; set; }
		}

		#region Variebles

		protected DoubleNode Head;
		protected DoubleNode Tail;
		protected DoubleNode CurrentNode;

		#endregion
		public DoubleLinkedList()
		{
			
		}

		public DoubleLinkedList(params T[] parameters)
		{
			foreach (T t in parameters)
				Add(t);
		}

		public IEnumerator<T> GetEnumerator()
		{
			DoubleNode temp = Head;
			while (temp != null)
			{
				yield return temp.Value;
				temp = temp.Next;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public void Add(T item)
		{
			DoubleNode temp = new DoubleNode(item);
			if (Head == null)
			{
				Head = temp;
				Tail = temp;
				CurrentNode = temp;
			}
			else
			{
				Tail.Next = temp;
				temp.Previous = Tail;
				Tail = temp;
			}

		}
		public void Clear()
		{
			CurrentNode = null;
			Head = null;
			Tail = null;
		}
		public bool Contains(T item)
		{
			DoubleNode temp = Head;
			while (temp != null && temp.Value.CompareTo(item) != 0)
			{
				temp = temp.Next;
			}
			if (temp == null)
				return false;
			else
				return true;
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (Head == null)
				return;
			DoubleNode temp = Head;
			for (int i = arrayIndex; i < array.Length; i++)
			{
				array[i] = temp.Value;
				if (temp.Next == null)
					return;
				temp = temp.Next;
			}
		}
		public bool Remove(T item)
		{
			//Starting
			if (Head == null)
				return false;
			DoubleNode temp = Head;

			//If our item is head
			if (temp.Value.CompareTo(item) == 0)
			{
				if (Head == Tail)
					Head = Tail = null;
				else
				{
					Head = Head.Next;
					Head.Previous = null;
				}
				return true;
			}
			//Looking for item in the middle of the list
			while (temp.Next != null && temp.Next.Value.CompareTo(item) != 0)
				temp = temp.Next;
			//Removing tails
			if (temp == Tail)
			{
				Tail = Tail.Previous;
				Tail.Next = null;
				return true;
			}
			//Checking our result
			if (temp.Next != null)
			{

				temp.Previous.Next = temp.Next;
				temp.Next.Previous = temp.Previous;
				return true;
			}
			//if no one of our is not true we just return false
			return false;
		}
		public int Count
		{
			get
			{
				if (Head == null)
					return 0;
				DoubleNode temp = Head;
				int count = 1;
				while (temp.Next!=null)
				{
					count++;
					temp = temp.Next;
				}
				return count;
			}
		}
		public bool IsReadOnly => false;
		public void Dispose()
		{
			Clear();
		}
		public bool MoveNext()
		{
			if (CurrentNode?.Next == null)
				return false;
			CurrentNode = CurrentNode.Next;
			return true;
		}
		public void Reset()
		{
			CurrentNode = Head;
		}
		public T Current => CurrentNode.Value;
		object IEnumerator.Current => Current;
	}
}