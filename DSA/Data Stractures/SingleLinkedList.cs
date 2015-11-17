using System;
using System.Collections;
using System.Collections.Generic;
using DSA.Interfaces;

namespace DSA
{
	/// <summary>
	/// Or own data structure what represent Single Linked list
	/// </summary>
	/// <typeparam name="T">T is element what should implement interface IComparable</typeparam>
	public class SingleLinkedList<T> :ICollection<T>,IBag<T> where T : IComparable
	{
		public class Node
		{
			public Node(T value)
			{
				Value = value;
			}

			internal T Value;
			internal Node Next { get; set; }
		}

		public SingleLinkedList()
		{

		}

		public SingleLinkedList(params T[]parameters)
		{
			foreach (T variable in parameters)
			{
				Add(variable);
			}
				
		}
		private Node _head;
		private Node _tail;
		private Node _current;
		public int Count {
			get
			{
				if (_head == null)
					return 0;
				Node temp = _head;
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

		public T Current
		{
			get
			{
				if (_current == null)
				{
					if (_head == null)
						throw new NullReferenceException();
					else
						_current = _head;
				}
				return _current.Value;
			}
		}

		/// <summary>
		/// Add the item to the end of our linked List
		/// </summary>
		/// <param name="item">The item that we want add</param>
		public void Add(T item)
		{
			Node temp = new Node(item);
			if (_head == null)
			{
				_head = temp;
				_tail = temp;
				_current = _head;
			}
			else
			{
				_tail.Next = temp;
				_tail = temp;
			}

		}

		//Check is our Linked list contain the value
		public bool Contains(T item)
		{
			Node temp = _head;
			while (temp!=null&&temp.Value.CompareTo(item)!=0)
			{
				temp = temp.Next;
			}
			if (temp == null)
				return false;
			else
				return true;
		}

		public void Dispose()
		{
			Clear();
		}

		public bool MoveNext()
		{
			if (_current?.Next == null)
				return false;
			_current = _current.Next;
			return true;
		}

		/// <summary>
		/// Reset our current to the first node
		/// </summary>
		public void Reset()
		{
			_current = _head;
		}


		object IEnumerator.Current => Current;

		public IEnumerator<T> GetEnumerator()
		{
			Node temp = _head;
			while (temp!=null)
			{
				yield return temp.Value;
				temp=temp.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Clear()
		{
			_current = null;
			_head = null;
			_tail = null;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if(_head==null)
				return;
			Node temp = _head;
			for (int i = arrayIndex; i < array.Length; i++)
			{
				array[i] = temp.Value;
				if(temp.Next==null)
					return;
				temp = temp.Next;
			}
		}

		public bool Remove(T item)
		{
			//Starting
			if (_head == null)
				return false;
			Node temp = _head;

			//If our item is head
			if (temp.Value.CompareTo(item) == 0)
			{
				if (_head == _tail)
					_head = _tail = null;
				else
					_head = _head.Next;
				return true;
			}
			//Looking for item in the middle of the list
			while (temp.Next != null && temp.Next.Value.CompareTo(item) != 0)
				temp = temp.Next;
			//Checking our result
			if (temp.Next != null)
			{
				//If our item is tails we remove the tail
				if (temp.Next == _tail)
				{
					_tail = temp;
					temp.Next = null;
					return true;
				}
				//if we got it somewhere in the middle
				temp.Next = temp.Next.Next;
				return true;
			}
			//if no one of our is not true we just return false
			return false;
		}
	}
}
