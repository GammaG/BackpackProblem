using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backpack
{
    public partial class MainForm : Form
    {
        
        private List<BackpackObject> objectList;
        private float currentValue;
        public MainForm()
        {
            InitializeComponent();
            loadItems();

        }

        private void loadItems()
        {
            StreamReader sr = new StreamReader(Constants.FILEPATH);
            currentValue = float.Parse(sr.ReadLine(), Constants.FORMAT_PROVIDER);

            objectList = new List<BackpackObject>();
            int index = 0;

            while (!sr.EndOfStream)
            {
                string[] sArray = sr.ReadLine().Split(' ');
                float weight = float.Parse(sArray[0], Constants.FORMAT_PROVIDER);
                float value = float.Parse(sArray[1], Constants.FORMAT_PROVIDER);
                objectList.Add(new BackpackObject(++index, weight, value));
            }
            sr.Close();

            objectList.Sort();
            appendResultBox(objectList.Count + " objects have been loaded.\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculateItems();
        }

        private void calculateItems()
        {
            // Algorithmus
            int i = objectList.Count - 1;
            while (i > 0 && currentValue > 0)
            {
                float wgt = objectList[i].Weight;
                if (currentValue >= wgt)
                {
                    currentValue -= wgt;
                    --i;
                }
                else
                {
                    currentValue = -currentValue;
                }
            }

            // Ausgabe
            for (int j = objectList.Count - 1; j > i; --j)
            {
                appendResultBox(objectList[j].ToString());
                appendResultBox(" - vollstaendig");
            }

            if (i >= 0 && currentValue < 0)
            {
                appendResultBox(objectList[i].ToString());
                appendResultBox(" - ");
                appendResultBox((-currentValue).ToString("F2", Constants.FORMAT_PROVIDER));
                appendResultBox(" kg");
            }


        }




        private void appendResultBox(String text)
        {
            resultBox.AppendText("\r\n" + text);
        }

        private void clearResultBox()
        {
            resultBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearResultBox();
        }

        

    }
}
