using System;
using Xunit;

namespace KellyStuard.Noip.UnitTest
{
	public sealed class QueryStringBuilderTests
	{
		[Fact]
		public void NewBuilderShouldBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			var result = builder.ToString();

			// assert
			Assert.Equal("", result);
		}

		[Fact]
		public void BuilderWithNullsShouldThrow()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			Action result = () => builder.Add(null, (string)null);

			// assert
			Assert.Throws<ArgumentNullException>("name", result);
		}

		[Fact]
		public void BuilderWithNullNameShouldThrow()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			Action result = () => builder.Add(null, "bar");

			// assert
			Assert.Throws<ArgumentNullException>("name", result);
		}

		[Fact]
		public void BuilderWithNullValueShouldThrow()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			Action result = () => builder.Add("foo", (string)null);

			// assert
			Assert.Throws<ArgumentNullException>("value", result);
		}

		[Fact]
		public void BuilderWithNullValuesShouldThrow()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			Action result = () => builder.Add("foo", new string[] { null });

			// assert
			Assert.Throws<ArgumentNullException>("value", result);
		}

		[Fact]
		public void BuilderWithSingleAddShouldHaveSingleParam()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value");
			var result = builder.ToString();

			// assert
			Assert.Equal("?first=value", result);
		}

		[Fact]
		public void BuilderWithDoubleAddShouldHaveDoubleParam()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value1");
			builder.Add("second", "value2");
			var result = builder.ToString();

			// assert
			Assert.Equal("?first=value1&second=value2", result);
		}

		[Fact]
		public void BuilderWithDoubleAddSameKeyShouldHaveSingleParam()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value1");
			builder.Add("first", "value2");
			var result = builder.ToString();

			// assert
			Assert.Equal("?first=value1,value2", result);
		}

		[Fact]
		public void BuilderWithSingleAddListShouldHaveSingleParam()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value1", "value2");
			var result = builder.ToString();

			// assert
			Assert.Equal("?first=value1,value2", result);
		}

		[Fact]
		public void BuilderWithRemoveNullShouldThrow()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			Action result = () => builder.Remove(null);

			// assert
			Assert.Throws<ArgumentNullException>("name", result);
		}

		[Fact]
		public void BuilderWithRemoveEmptyShouldHaveReturnFalseAndBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			var removed = builder.Remove("first");
			var result = builder.ToString();

			// assert
			Assert.False(removed);
			Assert.Equal("", result);
		}

		[Fact]
		public void BuilderWithAddRemoveShouldHaveReturnTrueAndBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value");
			var removed = builder.Remove("first");
			var result = builder.ToString();

			// assert
			Assert.True(removed);
			Assert.Equal("", result);
		}

		[Fact]
		public void BuilderWithEmptyResetShouldBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Reset();
			var result = builder.ToString();

			// assert
			Assert.Equal("", result);
		}

		[Fact]
		public void BuilderWithSingleAddResetShouldBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			builder.Add("first", "value");
			builder.Reset();
			var result = builder.ToString();

			// assert
			Assert.Equal("", result);
		}

		[Fact]
		public void EmptyBuilderToStringShouldBeEmpty()
		{
			// arrange
			var builder = new QueryStringBuilder();

			// act
			var result = builder.ToString();

			// assert
			Assert.Equal("", result);
		}
	}
}
