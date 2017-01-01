using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calcbox.Text = "0";
            calUnit.init();
        }

        CalsUnit calUnit = new CalsUnit();

        private void Button_AC_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.Clear();
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.OpePlus();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(1);
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(2);
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(3);
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(4);
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(5);
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(6);
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(7);
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(8);
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(9);
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.OpeEqual();
        }

        private void button_div_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.OpeDiv();
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.OpeMul();
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.OpeMinus();
        }

        private void button_reverse_Click(object sender, EventArgs e)
        {

        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputDot();
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            calcbox.Text = calUnit.InputFigure(0);
        }
    }

    public enum CalcOperater
    {
        NONE,
        PLUS,
        MINUS,
        MUL,
        DIV
    }

    public class CalInputValue
    {
        string inputValueString = "0";

        public void Clear()
        {
            inputValueString = "0";
        }

        public string InputFigure(int value)
        {
            if(inputValueString=="0")
            {
                inputValueString = "";
            }
            inputValueString += value;

            return inputValueString;
        }
        public string InputDot()
        {
            if (inputValueString.IndexOf('.') >= 0) return inputValueString;
            inputValueString += '.';
            return inputValueString;
        }

        public string GetInputString()
        {
            return inputValueString;
        }
        public double GetInputValue()
        {
            return double.Parse(inputValueString);
        }
    }

    public class CalsUnit
    {
        public double preValue;

        public long inputValue;
        public string inputValueString;
        public CalInputValue calInputValue = new CalInputValue();

        public bool existInput;
        CalcOperater opeMode;

        public void init()
        {
            preValue = 0;
            calInputValue.Clear();
            existInput = false;
            opeMode = CalcOperater.NONE;
        }
        public string Clear()
        {
            preValue = 0;

            calInputValue.Clear();
            existInput = false;

            opeMode = CalcOperater.NONE;
            return "0";
        }
        public string InputFigure(int value)
        {
            existInput = true;
            return calInputValue.InputFigure(value);
        }
        public string InputDot()
        {
            return calInputValue.InputDot();
        }

        public string OpePlus()
        {
            string result = Calc();

            opeMode = CalcOperater.PLUS;

            return result;
        }
        public string OpeDiv()
        {
            string result = Calc();
            opeMode = CalcOperater.DIV;
            return result;
        }
        public string OpeEqual()
        {
            string result = Calc();

            opeMode = CalcOperater.NONE;
            return result;
        }
        public string OpeMul()
        {
            string result = Calc();
            opeMode = CalcOperater.MUL;
            return result;
        }
        public string OpeMinus()
        {
            string result = Calc();
            opeMode = CalcOperater.MINUS;
            return result;
        }

        public string Calc()
        {
            double result = 0;
            switch(opeMode)
            {
                case CalcOperater.NONE:
                    if (existInput)
                    {
                        preValue = calInputValue.GetInputValue();
                        calInputValue.Clear();
                        existInput = false;

                        result = preValue;
                        return preValue.ToString();
                    }
                    else
                    {
                        return preValue.ToString();
                    }
                    break;
                case CalcOperater.PLUS:
                    if (existInput)
                    {
                        preValue += calInputValue.GetInputValue();
                    }
                    else
                    {
                        preValue = calInputValue.GetInputValue();
                    }
                    calInputValue.Clear();
                    existInput = false;
                    result = preValue;
                    return preValue.ToString();
                    break;
                case CalcOperater.MINUS:
                    if (existInput)
                    {
                        preValue -= calInputValue.GetInputValue();
                    }
                    else
                    {
                        preValue = calInputValue.GetInputValue();
                    }
                    calInputValue.Clear();
                    existInput = false;
                    result = preValue;
                    return preValue.ToString();
                    break;
                case CalcOperater.MUL:
                    if (existInput)
                    {
                        preValue *= calInputValue.GetInputValue();
                    }
                    else
                    {
                        preValue = calInputValue.GetInputValue();
                    }
                    existInput = false;
                    result = preValue;
                    return preValue.ToString();
                    break;
                case CalcOperater.DIV:
                    if(existInput)
                    {
                        if(calInputValue.GetInputValue()==0)
                        {
                            return "エラー";
                        }
                        preValue /= calInputValue.GetInputValue();
                    }
                    else
                    {
                        preValue = calInputValue.GetInputValue();
                    }
                    existInput = false;
                    result = preValue;
                    return preValue.ToString();
                    break;
            }

            return preValue.ToString();
        }
    }
}
