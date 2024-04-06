<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main() {
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	GetGreeting("Bob").Dump();
}

// You can define other methods, fields, classes and namespaces here

private string GetGreeting(string name) {
	return $"Hello {name}";
}
