# Props Enum sample

```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2861/23H2/2023Update/SunValley3)
11th Gen Intel Core i5-1135G7 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method              | Mean         | Error      | StdDev     |
|-------------------- |-------------:|-----------:|-----------:|
| IsEnabled           | 1,144.101 ns | 22.6558 ns | 54.7162 ns |
| IsEnabledUsingCache |     9.544 ns |  0.2150 ns |  0.1906 ns |
