using System.Linq;
using DSA;
using NUnit.Framework;

namespace MyDSA.Tests
{
	[TestFixture]
	public class DoubleLinkedListTest
	{

		public DoubleLinkedList<int> MyDoubleLinkedList;
		[SetUp]
		public void SetUp()
		{
			MyDoubleLinkedList= new DoubleLinkedList<int>();
		}

		[Test]
		public void EmptyListTest()
		{
			Assert.AreEqual(null, MyDoubleLinkedList.Current);
		}

		[Test]
		public void SingleItemTest()
		{
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(5, MyDoubleLinkedList.Current);
		}

		[Test]
		public void SearchingWithOneItemTest()
		{
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(5));
		}

		[Test]
		public void SearchingWithThreeElementTest()
		{
			MyDoubleLinkedList.Add(5);
			MyDoubleLinkedList.Add(6);
			MyDoubleLinkedList.Add(3);
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(3));
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(6));
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(5));
			Assert.AreEqual(false, MyDoubleLinkedList.Contains(10));
			Assert.AreEqual(false, MyDoubleLinkedList.Contains(8));
		}

		[Test]
		public void RemovingItemsTest()
		{
			
			MyDoubleLinkedList.Add(5);
			MyDoubleLinkedList.Add(6);
			MyDoubleLinkedList.Add(3);
			Assert.AreEqual(true, MyDoubleLinkedList.Remove(5));
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(3));
			Assert.AreEqual(true, MyDoubleLinkedList.Contains(6));
			Assert.AreEqual(false, MyDoubleLinkedList.Contains(5));

			Assert.AreEqual(true, MyDoubleLinkedList.Remove(6));
			Assert.AreEqual(true, MyDoubleLinkedList.Remove(3));
			Assert.AreEqual(false, MyDoubleLinkedList.Remove(5));

			Assert.AreEqual(false, MyDoubleLinkedList.Remove(5));
			Assert.AreEqual(false, MyDoubleLinkedList.Contains(3));
		}

		[Test]
		public void MoveNextTest()
		{
			Assert.AreEqual(false, MyDoubleLinkedList.MoveNext());
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(false, MyDoubleLinkedList.MoveNext());
			MyDoubleLinkedList.Add(8);
			MyDoubleLinkedList.Add(1000);

			Assert.AreEqual(5, MyDoubleLinkedList.Current);
			Assert.AreEqual(true, MyDoubleLinkedList.MoveNext());
			Assert.AreEqual(8, MyDoubleLinkedList.Current);
			Assert.AreEqual(true, MyDoubleLinkedList.MoveNext());
			Assert.AreEqual(1000, MyDoubleLinkedList.Current);
			Assert.AreEqual(false, MyDoubleLinkedList.MoveNext());
		}

		[Test]
		public void ResetTest()
		{
			MyDoubleLinkedList.Add(5);
			MyDoubleLinkedList.Add(8);
			MyDoubleLinkedList.Add(258);
			Assert.AreEqual(5, MyDoubleLinkedList.Current);
			Assert.AreEqual(true, MyDoubleLinkedList.MoveNext());
			Assert.AreEqual(8, MyDoubleLinkedList.Current);
			MyDoubleLinkedList.Reset();
			Assert.AreEqual(5, MyDoubleLinkedList.Current);
			

			
		}

		[Test]
		public void CountTest()
		{
			Assert.AreEqual(0, MyDoubleLinkedList.Count);
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(1, MyDoubleLinkedList.Count);
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(2, MyDoubleLinkedList.Count);
			MyDoubleLinkedList.Add(8);
			Assert.AreEqual(3, MyDoubleLinkedList.Count);
		}

		[Test]
		public void TravelingTestTest()
		{
			int[] a = MyDoubleLinkedList.ToArray();
			Assert.AreEqual(new int[0], a);
			MyDoubleLinkedList.Add(5);
			Assert.AreEqual(new[] { 5 }, MyDoubleLinkedList.ToArray());
			MyDoubleLinkedList.Add(20);
			Assert.AreEqual(new[] { 5, 20 }, MyDoubleLinkedList.ToArray());
			MyDoubleLinkedList.Add(-20);
			Assert.AreEqual(new[] { 5, 20, -20 }, MyDoubleLinkedList.ToArray());
			MyDoubleLinkedList.Clear();
			Assert.AreEqual(new int[] { }, MyDoubleLinkedList.ToArray());
		}
		[TearDown]
		public void TearDown()
		{
			MyDoubleLinkedList = null;
		}


	}
} 