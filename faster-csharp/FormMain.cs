using System.Collections;
using System.Diagnostics;
using System.Buffers;

namespace faster_csharp
{
    class MyClass
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    struct MyStruct
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonGCvsLoop_Click(object sender, EventArgs e)
        {
            this.textBoxOutput.Text += $"===== GC.Collect() vs Loop ====={Environment.NewLine}";
            var watch = System.Diagnostics.Stopwatch.StartNew();
            /* Beginning with C# 3, variables that are declared at method scope can have an
             * implicit "type" var. An implicitly typed local variable is strongly typed just
             * as if you had declared the type yourself, but the compiler determines the type. 
             * For this particular case, var watch is equal to System.Diagnostics.Stopwatch watch
             */
            for (int i = 0; i < 1000; i++)
            {
                long a = 0;
                for (int j = 0; j < 50 * 1000; j++)
                {
                    a += j;
                }
            }
            watch.Stop();
            this.textBoxOutput.Text += $"50,000 iterations: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            Application.DoEvents();

            watch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                System.GC.Collect();
            }
            this.textBoxOutput.Text += $"GC.Collect(): {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            this.textBoxOutput.Text += $"\"a GC.Collect() call is worth 50 thousand iterations\"{Environment.NewLine}";
        }

        private void buttonStaticVSDynamicArraies_Click(object sender, EventArgs e)
        {
            this.textBoxOutput.Text += $"===== Static vs Dynamic Arraies ====={Environment.NewLine}";

            const int NumberOfItems = 10 * 1000 * 1000;
            var watch = System.Diagnostics.Stopwatch.StartNew();

            watch.Start();
            int[] vanillaArray = new int[NumberOfItems];
            for (int i = 0; i < NumberOfItems; i++)
            {
                vanillaArray[i] = i;
            }
            watch.Stop();
            this.textBoxOutput.Text += $"vanillaArray: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            Application.DoEvents();
            System.GC.Collect();

            watch.Restart();
            ArrayList preAllocatedArrayList = new ArrayList();
            for (int i = 0; i < NumberOfItems; i++)
            {
                preAllocatedArrayList.Add(i);
            }
            watch.Stop();
            this.textBoxOutput.Text += $"preAllocatedArrayList: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            Application.DoEvents();
            System.GC.Collect();

            watch.Restart();
            ArrayList naiveArrayList = new ArrayList(NumberOfItems);
            for (int i = 0; i < NumberOfItems; i++)
            {
                naiveArrayList.Add(i);
            }
            this.textBoxOutput.Text += $"naiveArrayList: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";

        }

        private void buttonArrayVSArrayPool_Click(object sender, EventArgs e)
        {
            this.textBoxOutput.Text += $"===== Array vs ArrayPool ====={Environment.NewLine}";
            const int NumberOfItems = 10000;
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                int[] array = new int[NumberOfItems];
            }
            watch.Stop();
            this.textBoxOutput.Text += $"Array: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            Application.DoEvents();

            watch.Restart();
            // ArrayPool does not appear to be supported in .NET Framework 4.8
            for (int i = 0; i < 100000; i++)
            {
                var pool = ArrayPool<int>.Shared;
                int[] array = pool.Rent(NumberOfItems);
                // need to remember is that it has a default max array length, equal to 2^20 (1024*1024 = 1 048 576).
                pool.Return(array);
                // Returns an array to the pool that was previously obtained using the Rent(Int32) method on the same ArrayPool<T> instance.
                /* Once a buffer has been returned to the pool, the caller gives up all
                 * ownership of the buffer and must not use it. The reference returned from
                 * a given call to the Rent method must only be returned using the Return method once.*/
            }
            this.textBoxOutput.Text += $"ArrayPool: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
        }

        private void buttonStructVSClass_Click(object sender, EventArgs e)
        {
            this.textBoxOutput.Text += $"===== Struct vs Class ====={Environment.NewLine}";
            const int NumberOfItems = 1000 * 1000;
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            MyClass[] myClasses = new MyClass[NumberOfItems];
            for (int i = 0; i < NumberOfItems; i++)
            {
                myClasses[i] = new MyClass();
                myClasses[i].A = i+1;
                myClasses[i].B = i+2;
                myClasses[i].C = i+3;
                myClasses[i].X = i+4;
                myClasses[i].Y = i+5;
                myClasses[i].Z = i+6;
            }
            watch.Stop();
            this.textBoxOutput.Text += $"Class: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
            Application.DoEvents();

            watch.Restart();
            MyStruct[] myStructs = new MyStruct[NumberOfItems];
            for (int i = 0; i < NumberOfItems; i++)
            {
                myStructs[i] = new MyStruct();
                myStructs[i].A = i+1;
                myStructs[i].B = i+2;
                myStructs[i].C = i+3;
                myStructs[i].X = i+4;
                myStructs[i].Y = i+5;
                myStructs[i].Z = i+6;
            }
            this.textBoxOutput.Text += $"Struct: {watch.ElapsedMilliseconds} ms{Environment.NewLine}";
        }
    }
}