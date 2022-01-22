using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("X/V");
			Assert.AreEqual(2, result);
		}
		[Test]
		public void Test2()
		{
			var result = Service.Evaluate("L+IV");
			Assert.AreEqual(54, result);
		}
		[Test]
		public void Test3()
		{
			var result = Service.Evaluate("II*IV-V");
			Assert.AreEqual(3, result);
		}
		[Test]
		public void Test4()
		{
			var result = Service.Evaluate("III/IV*II");
			Assert.AreEqual(0, result);
		}
		[Test]
		public void Test5()
		{
			var result = Service.Evaluate("IV/IV*II");
			Assert.AreEqual(2, result);
		}
		[Test]
		public void Test6()
		{
			var result = Service.Evaluate("IIV*II");
			Assert.AreEqual(6, result);
		}

		[Test]
		public void Test7()
		{
			var result = Assert.Throws<ArgumentException>(()=> Service.Evaluate(""));
			Assert.AreEqual(result.Message, "You missing expression.");
		}
		[Test]
		public void Test8()
		{
			var result = Assert.Throws<ArgumentException>(() => Service.Evaluate("IVL*II"));
			Assert.AreEqual(result.Message, "Incorrect roman number format.");
		}
		[Test]
		public void Test9()
		{
			var result = Assert.Throws<ArgumentException>(() => Service.Evaluate("L**II"));
			Assert.AreEqual(result.Message, "Not a valid math expression.");
		}
		[Test]
		public void Test10()
		{
			var result = Assert.Throws<ArgumentException>(() => Service.Evaluate("IIIIIIIX*1"));
			Assert.AreEqual(result.Message, "Incorrect input character.");
		}
	}
}