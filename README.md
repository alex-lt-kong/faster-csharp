# faster-csharp

Experiments that make C# faster with**OUT** optimizing the time complexity of algorithms.

# Results

===== GC.Collect() vs Loop =====\
50,000 iterations: 128 ms\
GC.Collect(): 634 ms\
"a GC.Collect() call is worth 50 thousand iterations"


===== Static vs Dynamic Arraies =====\
vanillaArray: 35 ms\
preAllocatedArrayList: 1083 ms\
naiveArrayList: 960 ms


===== Array vs ArrayPool =====\
Array: 49 ms\
ArrayPool: 3 ms\


===== Class vs Struct vs Dict =====\
Class: 108 ms\
Struct: 39 ms\
Dictionary: 1608 ms\


===== Try vs No try =====\
try{}ed: 43 ms\
not try{}ed: 24 ms\
"There IS harm in try{}ing"\


===== Finalizer vs No Finalizer =====\
Class: 106 ms\
Class with a finalizer: 252 ms\


===== String vs StringBuilder =====\
StringBuilder: 7 ms\
String: 29474 ms

