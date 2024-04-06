<Query Kind="Program">
  <Output>DataGrids</Output>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "GetGreeting"

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

[Fact] void Test_GetGreeting_OK() => Assert.Equal("Hello Bob", GetGreeting("Bob"));
[Fact] void Test_GetGreeting_NG() => Assert.NotEqual("Hello Bob", GetGreeting("Alice"));

#endregion