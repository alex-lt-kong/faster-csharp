using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace faster_csharp
{
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
            for (int i = 0; i < 1000; i++) {
                long a = 0;
                for (int j = 0; j< 50 * 1000; j++) { 
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
    }
}
