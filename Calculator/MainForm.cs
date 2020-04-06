using Calculator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        string oprationPerformed;
        Double? resultValue = null;
        Double? lastresultValue = null;

        public MainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (textBoxResult.Text == "0" && button.Text == ".") { }
            else if (textBoxResult.Text == "0")
            {
                textBoxResult.Clear();
            }

            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                {
                    textBoxResult.Text = textBoxResult.Text + button.Text;
                }
            }
            else
            {
                textBoxResult.Text = textBoxResult.Text + button.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;


            if (textBoxResult.Text == "0" || textBoxResult.Text == "" || textBoxResult.Text == "." || textBoxResult.Text == "0.")
            {
                oprationPerformed = button.Text;
            }
            else if ((resultValue == 0 || resultValue == null) && button.Text != "=" && (textBoxResult.Text != "0" || textBoxResult.Text != "" || textBoxResult.Text != "." || textBoxResult.Text != "0."))
            {
                resultValue = Double.Parse(textBoxResult.Text);
                oprationPerformed = button.Text;
                textBoxResult.Text = "0";
            }
            else if ((lastresultValue == 0 || lastresultValue == null) && (textBoxResult.Text != "0" || textBoxResult.Text != "" || textBoxResult.Text != "." || textBoxResult.Text != "0."))
            {
                switch (oprationPerformed)
                {
                    case "+":
                        lastresultValue = (resultValue + Double.Parse(textBoxResult.Text));
                        break;
                    case "-":
                        lastresultValue = (resultValue - Double.Parse(textBoxResult.Text));
                        break;
                    case "/":
                        lastresultValue = (resultValue / Double.Parse(textBoxResult.Text));
                        break;
                    case "*":
                        lastresultValue = (resultValue * Double.Parse(textBoxResult.Text));
                        break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBoxResult.Text);
                oprationPerformed = button.Text;
                textBoxResult.Text = "0";
            }
            else if ((lastresultValue != 0 || lastresultValue != null))
            {
                switch (oprationPerformed)
                {
                    case "+":
                        lastresultValue = (lastresultValue + Double.Parse(textBoxResult.Text));
                        break;
                    case "-":
                        lastresultValue = (lastresultValue - Double.Parse(textBoxResult.Text));
                        break;
                    case "/":
                        lastresultValue = (lastresultValue / Double.Parse(textBoxResult.Text));
                        break;
                    case "*":
                        lastresultValue = (lastresultValue * Double.Parse(textBoxResult.Text));
                        break;
                    default:
                        break;
                }
                resultValue = Double.Parse(textBoxResult.Text);
                oprationPerformed = button.Text;
                textBoxResult.Text = "0";
            }

            if (button.Text == "=")
            {
                textBoxResult.Text = lastresultValue.ToString();
                resultValue = null;
                lastresultValue = null;
                oprationPerformed = "";

            }
            else if (!(textBoxResult.Text == "0" || textBoxResult.Text == "" || textBoxResult.Text == "." || textBoxResult.Text == "0."))
            {
                oprationPerformed = button.Text;
                
            }

            labelStoredOperation.Text = resultValue + " " + oprationPerformed;
            labelStoredOperationEqual.Text = lastresultValue.ToString();
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultValue = null;
            lastresultValue = null;
            labelStoredOperation.Text = "";
            labelStoredOperationEqual.Text = "";
            oprationPerformed = "";

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    button_Click(button0, e);
                    break;
                case Keys.NumPad1:
                    button_Click(button1, e);
                    break;
                case Keys.NumPad2:
                    button_Click(button2, e);
                    break;
                case Keys.NumPad3:
                    button_Click(button3, e);
                    break;
                case Keys.NumPad4:
                    button_Click(button4, e);
                    break;
                case Keys.NumPad5:
                    button_Click(button5, e);
                    break;
                case Keys.NumPad6:
                    button_Click(button6, e);
                    break;
                case Keys.NumPad7:
                    button_Click(button7, e);
                    break;
                case Keys.NumPad8:
                    button_Click(button8, e);
                    break;
                case Keys.NumPad9:
                    button_Click(button9, e);
                    break;

                case Keys.OemMinus:
                case Keys.Subtract:
                    operator_Click(buttonMinus, e);
                    break;

                case Keys.Oemplus:
                case Keys.Add:
                    operator_Click(buttonPlus, e);
                    break;

                case Keys.OemQuestion:
                case Keys.Divide:
                    operator_Click(buttonDivide, e);
                    break;

                case Keys.D8:
                case Keys.Multiply:
                    operator_Click(buttonMultiply, e);
                    break;

                case Keys.OemPeriod:
                case Keys.Decimal:
                    operator_Click(buttonPoint, e);
                    break;

                case Keys.Delete:
                    buttonClearEntry_Click(0, e);
                    break;

                case Keys.Back:
                    buttonClear_Click(0, e);
                    break;

                case Keys.Return:
                    operator_Click(buttonEquals, e);
                    break;
                default:
                    break;
            }
            
            if (e.KeyCode == Keys.P)
            {
                textBoxResult.Text = "3.14159265";
                textBoxResult.SelectionStart = textBoxResult.Text.Length;
            }
            else if (e.KeyCode == Keys.S)
            {
                MessageBox.Show("This was design by Saman.K");
                this.Text = ("Calculator | Saman.K");
            }
        }

        private void textBoxResult_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.OemMinus:
                case Keys.Subtract:
                    operator_Click(buttonMinus, e);
                    break;

                case Keys.Oemplus:
                case Keys.Add:
                    operator_Click(buttonPlus, e);
                    break;

                case Keys.OemQuestion:
                case Keys.Divide:
                    operator_Click(buttonDivide, e);
                    break;

                case Keys.D8:
                case Keys.Multiply:
                    operator_Click(buttonMultiply, e);
                    break;

                case Keys.OemPeriod:
                case Keys.Decimal:
                    operator_Click(buttonPoint, e);
                    break;

                case Keys.Return:
                    operator_Click(buttonEquals, e);
                    textBoxResult.SelectionStart = 0;
                    textBoxResult.SelectionLength = textBoxResult.Text.Length;
                    break;
                default:
                    break;
            }
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Multiply || e.KeyCode == Keys.D8 || e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                textBoxResult.Text = "";
            }
            if (e.KeyCode == Keys.P)
            {
                textBoxResult.Text = "3.14159265";
                textBoxResult.SelectionStart = textBoxResult.Text.Length;

            }
            else if (e.KeyCode == Keys.S)
            {

                MessageBox.Show("This was design by Saman.K");
                this.Text  = ("Calculator | Saman.K");

            }

        }

        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != 8 ;
        }

        private void textBoxResult_Click(object sender, EventArgs e)
        {
            if (textBoxResult.Text == "0")
            {
                textBoxResult.Clear();
            }
            textBoxResult.SelectionStart = 0;
            textBoxResult.SelectionLength = textBoxResult.Text.Length;
        }

        private void infoPicBox_Click(object sender, EventArgs e)
        {
            //AboutForm.Show();
        }
    }
}
