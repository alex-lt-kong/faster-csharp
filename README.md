# faster-csharp

Experiments that make C# faster with**OUT** optimizing the time complexity of algorithms.

# Results

===== GC.Collect() vs Loop =====
50,000 iterations: 127 ms
GC.Collect(): 627 ms
"a GC.Collect() call is worth 50 thousand iterations"
===== Static vs Dynamic Arraies =====
vanillaArray: 52 ms
preAllocatedArrayList: 965 ms
naiveArrayList: 996 ms
===== Array vs ArrayPool =====
Array: 76 ms
ArrayPool: 3 ms
===== Struct vs Class =====
Class: 191 ms
Struct: 78 ms

