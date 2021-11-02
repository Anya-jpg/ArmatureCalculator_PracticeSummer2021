using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Armature_Calculator
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Dia", "dia");
            table.Columns["Dia"].Width = 100;
            table.Columns.Add("One", "one");
            table.Columns["One"].Width = 134;
            table.Columns.Add("More", "more");
            table.Columns["More"].Width = 134;
            table.Columns.Add("WeightOne", "weightOne");
            table.Columns["WeightOne"].Width = 140;
            double s; 
           int dia = 2, decimals_num;
            for (int k =0;k<=16;k++)
           {
                k = table.Rows.Add();
            }
            int i = 0;
            string str_decimals;
            while (dia != 40)
            {
                str_decimals = decimals_updown.Value.ToString();
                decimals_num = Int32.Parse(str_decimals);
                if (dia >= 28 && dia <= 40) dia += 4;
                if (dia == 25 || dia == 22) dia += 3;
                if (dia >= 6 && dia <= 22) dia += 2;
                if (dia < 6) dia++;
                table.Rows[i].Cells["Dia"].Value = dia;
                s = (double)(Math.Pow(dia, 2) / (double)4) * 3.14;
                table.Rows[i].Cells["One"].Value = Math.Round(s / 100, decimals_num, MidpointRounding.AwayFromZero);
                table.Rows[i].Cells["More"].Value = Math.Round((s / 100) * 2, decimals_num, MidpointRounding.AwayFromZero);
                i++;
            }
            table.Rows[0].Cells["WeightOne"].Value = 0.055;
            table.Rows[1].Cells["WeightOne"].Value = 0.099;
            table.Rows[2].Cells["WeightOne"].Value = 0.154;
            table.Rows[3].Cells["WeightOne"].Value = 0.222;
            table.Rows[4].Cells["WeightOne"].Value = 0.395;
            table.Rows[5].Cells["WeightOne"].Value = 0.617;
            table.Rows[6].Cells["WeightOne"].Value = 0.888;
            table.Rows[7].Cells["WeightOne"].Value = 1.210;
            table.Rows[8].Cells["WeightOne"].Value = 1.580;
            table.Rows[9].Cells["WeightOne"].Value = 2.000;
            table.Rows[10].Cells["WeightOne"].Value = 2.470;
            table.Rows[11].Cells["WeightOne"].Value = 2.980;
            table.Rows[12].Cells["WeightOne"].Value = 3.850;
            table.Rows[13].Cells["WeightOne"].Value = 4.830;
            table.Rows[14].Cells["WeightOne"].Value = 6.310;
            table.Rows[15].Cells["WeightOne"].Value = 7.990;
            table.Rows[16].Cells["WeightOne"].Value = 9.870;
        }

        private void rods_num_updown_ValueChanged(object sender, EventArgs e)
        {
            int decimals_num, rods_num;
            string str_decimals, str_rods;
            str_rods = rods_num_updown.Value.ToString();
            rods_num = Int32.Parse(str_rods);
            str_decimals = decimals_updown.Value.ToString();
            decimals_num = Int32.Parse(str_decimals);
            double one = Convert.ToDouble(table[1, 0].Value);
            for (int i = 0; i <= 16; i++)
            {
                one = Convert.ToDouble(table[1, i].Value);
                table.Rows[i].Cells["More"].Value = Math.Round(rods_num * one, decimals_num, MidpointRounding.AwayFromZero);
            }
        }

        private void textBox_length_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double len, mul, weight = 0.055;
                int dia = Int32.Parse(comboBox_dia.Text);
                int diaTable;
                for (int i = 0; i <= 16; i++)
                {
                    diaTable = (int)table.Rows[i].Cells["Dia"].Value;
                    if (diaTable == dia)
                    {
                        weight = (double)table.Rows[i].Cells["WeightOne"].Value;
                    }
                }
                len = Double.Parse(textBox_length.Text);
                mul = weight * len;
                textBox_weightArm.Text = mul.ToString();
            }
            catch
            {
                if (textBox_length.Text.Length == 0)
                {
                    textBox_length.Text = null;
                    textBox_weightArm.Text = null;
                }

            }

        }

        private void textBox_length_KeyPress(object sender, KeyPressEventArgs e)
        { 
        if (e.KeyChar == '.') e.KeyChar = ',';
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }

        private void decimals_updown_ValueChanged(object sender, EventArgs e)
        {
            double s, one = Convert.ToDouble(table[1, 0].Value);
            int dia = 2, decimals_num, i = 0;
            string str_decimals;
            str_decimals = decimals_updown.Value.ToString();
            decimals_num = Int32.Parse(str_decimals);
            while (dia != 40)
            {
                if (dia >= 28 && dia <= 40) dia += 4;
                if (dia == 25 || dia == 22) dia += 3;
                if (dia >= 6 && dia <= 22) dia += 2;
                if (dia < 6) dia++;
                table.Rows[i].Cells["Dia"].Value = dia;
                s = (double)(Math.Pow(dia, 2) / (double)4) * 3.14;
                table.Rows[i].Cells["One"].Value = Math.Round(s / 100, decimals_num, MidpointRounding.AwayFromZero);
                i++;
            }
            string str_num = rods_num_updown.Value.ToString();
            int rods_num = Int32.Parse(str_num);
            for (int k = 0; k <= 16; k++)
            {
                one = Convert.ToDouble(table[1, k].Value);
                table.Rows[k].Cells["More"].Value = Math.Round(rods_num * one, decimals_num, MidpointRounding.AwayFromZero);
            }
        }

        private void textBox_weightArm1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton_kg.Checked == true)
                {
                    double weight = Double.Parse(textBox_weightArm1.Text), weightMetr = 0.055, kolvo, kolvoRods;
                    int dia = Int32.Parse(comboBox_dia1.Text);
                    int diaTable;
                    for (int i = 0; i <= 16; i++)
                    {
                        diaTable = (int)table.Rows[i].Cells["Dia"].Value;
                        if (diaTable == dia)
                        {
                            weightMetr = (double)table.Rows[i].Cells["WeightOne"].Value;
                        }
                    }
                    kolvo = Math.Round(weight / weightMetr, 2, MidpointRounding.AwayFromZero);
                    textBox_kolvoMetr.Text = kolvo.ToString();
                    kolvoRods = Math.Round(kolvo / 11.7, 1, MidpointRounding.AwayFromZero);
                    textBox_kolvoRods.Text = kolvoRods.ToString();
                }
                if (radioButton_ton.Checked == true)
                {
                    double weight = Double.Parse(textBox_weightArm1.Text), weightMetr = 0.055, kolvo, kolvoRods;
                    weight = weight * 1000;
                    int dia = Int32.Parse(comboBox_dia1.Text);
                    int diaTable;
                    for (int i = 0; i <= 16; i++)
                    {
                        diaTable = (int)table.Rows[i].Cells["Dia"].Value;
                        if (diaTable == dia)
                        {
                            weightMetr = (double)table.Rows[i].Cells["WeightOne"].Value;
                        }
                    }
                    kolvo = Math.Round(weight / weightMetr, 2, MidpointRounding.AwayFromZero);
                    textBox_kolvoMetr.Text = kolvo.ToString();
                    kolvoRods = Math.Round(kolvo / 11.7, 0, MidpointRounding.AwayFromZero);
                    textBox_kolvoRods.Text = kolvoRods.ToString();
                }
            }
            catch
            {
                if (textBox_weightArm1.Text.Length == 0)
                {
                    textBox_weightArm1.Text = null;
                    textBox_kolvoMetr.Text = null;
                }

            }
        }

        private void textBox_weightArm1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.') e.KeyChar = ',';
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
