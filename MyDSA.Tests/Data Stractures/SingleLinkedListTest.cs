using System;
using System.Collections.Generic;
using System.Linq;
using DSA;
using NUnit.Framework;

namespace MyDSA.Tests
{
	[TestFixture]
	public class SingleLinkedListTest
	{
		public SingleLinkedList<int> _myIntLinkedList;

		[SetUp]
		public void SetUp()
		{
			_myIntLinkedList = new SingleLinkedList<int>();
			//Setting up before every test 
		}

		[Test]
		public void EmptyListTest()
		{
			bool catchException = false;
			try
			{
				int x = _myIntLinkedList.Current;
			}
			catch (NullReferenceException)
			{
				catchException = true;
			}

			if (catchException)
				Assert.Pass();
			else
				Assert.Fail();
	
		}

		[Test]
		public void SingleItemTest()
		{
			_myIntLinkedList.Add(5);
			Assert.AreEqual(5, _myIntLinkedList.Current);
		}

		[Test]
		public void SearcingWithOneElementTest()
		{
			_myIntLinkedList.Add(4);
			Assert.AreEqual(true, _myIntLinkedList.Contains(4));
		}

		[Test]
		public void SearchingWithThreeElementsTest()
		{
			
			_myIntLinkedList.Add(5);
			_myIntLinkedList.Add(4);
			_myIntLinkedList.Add(6);
			Assert.AreEqual(true, _myIntLinkedList.Contains(4));
		}

		[Test]
		public void SearchingNotExistingElementTest()
		{
			
			_myIntLinkedList.Add(5);
			_myIntLinkedList.Add(4);
			_myIntLinkedList.Add(6);
			Assert.AreEqual(false, _myIntLinkedList.Contains(9));
		}

		[Test]
		public void RemovingItemTest()
		{
			
			_myIntLinkedList.Add(5);
			_myIntLinkedList.Add(4);
			_myIntLinkedList.Add(6);
			Assert.AreEqual(true, _myIntLinkedList.Remove(4));
			Assert.AreEqual(true, _myIntLinkedList.Contains(5));
			Assert.AreEqual(true, _myIntLinkedList.Contains(6));
			Assert.AreEqual(false, _myIntLinkedList.Contains(4));
		}

		[Test]
		public void RemovingHeadTest()
		{
			
			_myIntLinkedList.Add(4);
			Assert.AreEqual(true, _myIntLinkedList.Remove(4));

		}

		[Test]
		public void MoveNextTest()
		{
			Assert.AreEqual(false, _myIntLinkedList.MoveNext());
			_myIntLinkedList.Add(5);
			Assert.AreEqual(false, _myIntLinkedList.MoveNext());
			_myIntLinkedList.Add(258);
			_myIntLinkedList.Add(8);

			Assert.AreEqual(5, _myIntLinkedList.Current);
			Assert.AreEqual(true, _myIntLinkedList.MoveNext());
			Assert.AreEqual(258, _myIntLinkedList.Current);
			Assert.AreEqual(true, _myIntLinkedList.MoveNext());
			Assert.AreEqual(8, _myIntLinkedList.Current);
			Assert.AreEqual(false, _myIntLinkedList.MoveNext());
		}

		[Test]
		public void ResetTest()
		{
			_myIntLinkedList.Add(5);
			_myIntLinkedList.Add(258);
			_myIntLinkedList.Add(8);
			Assert.AreEqual(5, _myIntLinkedList.Current);
			Assert.AreEqual(true, _myIntLinkedList.MoveNext());
			Assert.AreEqual(258, _myIntLinkedList.Current);
			_myIntLinkedList.Reset();
			Assert.AreEqual(5, _myIntLinkedList.Current);

		}

		[Test]
		public void CountTest()
		{

			Assert.AreEqual(0, _myIntLinkedList.Count);
			_myIntLinkedList.Add(5);
			Assert.AreEqual(1, _myIntLinkedList.Count);
			_myIntLinkedList.Add(258);
			Assert.AreEqual(2, _myIntLinkedList.Count);
			_myIntLinkedList.Add(8);
			Assert.AreEqual(3, _myIntLinkedList.Count);
			_myIntLinkedList.Clear();
			Assert.AreEqual(0, _myIntLinkedList.Count);

		}

		[Test]
		public void TravelinTest()
		{
			int[] a = _myIntLinkedList.ToArray();
			Assert.AreEqual(new int [0], a);
			_myIntLinkedList.Add(5);
			Assert.AreEqual(new int[] {5}, _myIntLinkedList.ToArray());
			_myIntLinkedList.Add(20);
			Assert.AreEqual(new int[] {5,20}, _myIntLinkedList.ToArray());
			_myIntLinkedList.Add(-20);
			Assert.AreEqual(new int[] {5,20,-20}, _myIntLinkedList.ToArray());
			_myIntLinkedList.Clear();
			Assert.AreEqual(new int[] {}, _myIntLinkedList.ToArray());

		}
		[TearDown]
		public void TearDown()
		{
			_myIntLinkedList = null;
		}


	}
} 