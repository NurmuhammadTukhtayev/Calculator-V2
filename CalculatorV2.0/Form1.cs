using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorV2._0
{
    public partial class CalculatorForm : Form
    {
        // variables
        double a, b;
        char op = ' ';
        string problem="";
        bool setClear = false;
        
        // checks clear
        void check()
        {
            if (setClear == true)
            {
                inputBox.Text = "";
                setClear = false;
            }
        }

        //calculation
        private void calculation()
        {
            //inputBox.Text = Convert.ToString(problem.Split(op).Length);
            /*if (problem.Split(Convert.ToChar(prevOp)).Length == 3)
            {                
                a = double.Parse(problem.Split(Convert.ToChar(prevOp))[0]);
                b = double.Parse(problem.Split(Convert.ToChar(prevOp))[1]); */
                 switch (op)
                 {
                     case '+':
                         a += b;
                         break;
                     case '-':
                         a -= b;
                         break;
                     case '*':
                         a *= b;
                         break;
                     case '/':
                         a /= b;
                         break;
                     case '^':
                         a = Math.Pow(a, b);
                         break;
                     default:
                         break;
                 }

                 inputBox.Text = Convert.ToString(a);
                 problem = Convert.ToString(a)+op;
                
            //} 

        }
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void num1_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num1.Text);
            problem += Convert.ToString(num1.Text);
        }

        private void num2_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num2.Text);
            problem += Convert.ToString(num2.Text);
        }

        private void num3_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num3.Text);
            problem += Convert.ToString(num3.Text);
        }

        private void num4_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num4.Text);
            problem += Convert.ToString(num4.Text);
        }

        private void num5_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num5.Text);
            problem += Convert.ToString(num5.Text);
        }

        private void num6_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num6.Text);
            problem += Convert.ToString(num6.Text);
        }

        private void num7_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num7.Text);
            problem += Convert.ToString(num7.Text);
        }

        private void num8_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num8.Text);
            problem += Convert.ToString(num8.Text);
        }

        private void num9_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num9.Text);
            problem += Convert.ToString(num9.Text);
        }

        private void num0_Click(object sender, EventArgs e)
        {
            check();
            inputBox.Text += Convert.ToString(num0.Text);
            problem += Convert.ToString(num0.Text);
        }

        private void point_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.IndexOf(',') == -1)
            {
                inputBox.Text += Convert.ToString(point.Text);
            }

            if (op != ' ')
            {
                string[] k = problem.Split(Convert.ToChar(op));
                if (k[1].IndexOf(',') == -1)
                {
                    problem += ',';
                }
            }
            else
            {
                if (problem.IndexOf(',') == -1)
                {
                    problem += ',';
                }
            }
           
           
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            string s = "";
            for(int i = 0; i < inputBox.Text.Length-1; i++)
            {
                s += inputBox.Text[i];
            }

            inputBox.Text = s;

        }

        private void clear_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
        }

        // Keypress function
        private void inputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == Convert.ToChar(Keys.Back))  //backspace
            {
                backspace.PerformClick();
            }
            else if(key>='0' && key <= '9') // nums
            {
                check();
                inputBox.Text += key;
                problem += key;
            }
            else if (key==',')  // point key
            {
                point.PerformClick();
            }
            else if (key == Convert.ToChar(Keys.Escape)) //clear key escape
            {
                clearAll.PerformClick();
            }
            else if (key == '+')
            {
                plus.PerformClick();
            }
            else if (key=='-')
            {
                minus.PerformClick();
            }
            else if (key == '*')
            {
                multiply.PerformClick();
            }
            else if (key == '/')
            {
                devide.PerformClick();
            }
            else if (key == '^')
            {
                pow.PerformClick();
            }
            else if (key == Convert.ToChar(Keys.Enter))
            {
                equal.PerformClick();
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op) != -1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if (isA && isB)
                    calculation();
            }
            setClear = true;
            showBox.Text = problem;
        }

        // onclick plus
        private void plus_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op)!=-1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if (isA && isB)
                    calculation();
            }
            op= '+';
            // check last operation
            if (problem[problem.Length - 1] >= '0' && problem[problem.Length - 1] <= '9')
                problem += op;
            else
            {
                string temp = "";
                for (int i = 0; i < problem.Length - 1; i++)
                {
                    temp += problem[i];
                }
                temp += op;
                problem = temp;
            }
            setClear = true;
        }

        private void showBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op) != -1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if (isA && isB)
                    calculation();
            }
            op = '-';
            // check last operation
            if (problem[problem.Length - 1] >= '0' && problem[problem.Length - 1] <= '9')
                problem += op;
            else
            {
                string temp = "";
                for (int i = 0; i < problem.Length - 1; i++)
                {
                    temp += problem[i];
                }
                temp += op;
                problem = temp;
            }
            setClear = true;
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op) != -1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if (isA && isB)
                    calculation();
            }
            op = '*';
            // check last operation
            if (problem[problem.Length - 1] >= '0' && problem[problem.Length - 1] <= '9')
                problem += op;
            else
            {
                string temp = "";
                for (int i = 0; i < problem.Length - 1; i++)
                {
                    temp += problem[i];
                }
                temp += op;
                problem = temp;
            }
            setClear = true;
        }

        private void devide_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op) != -1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if(isA && isB)
                    calculation();
            }
            op = '/';
            // check last operation
            if (problem[problem.Length - 1] >= '0' && problem[problem.Length - 1] <= '9')
                problem += op;
            else
            {
                string temp = "";
                for (int i = 0; i < problem.Length - 1; i++)
                {
                    temp += problem[i];
                }
                temp += op;
                problem = temp;
            }
            setClear = true;
        }

        private void pow_Click(object sender, EventArgs e)
        {
            if (op != ' ' && problem.IndexOf(op) != -1)
            {
                bool isA = double.TryParse(problem.Split(op)[0], out a);
                bool isB = double.TryParse(problem.Split(op)[1], out b);
                if (isA && isB)
                    calculation();
            }
            op = '^';
            // check last operation
            if (problem[problem.Length - 1] >= '0' && problem[problem.Length - 1] <= '9')
                problem += op;
            else
            {
                string temp = "";
                for (int i = 0; i < problem.Length - 1; i++)
                {
                    temp += problem[i];
                }
                temp += op;
                problem = temp;
            }
            setClear = true;
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            op = ' ';
            problem = "";
            showBox.Text = "";
            inputBox.Text = "";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            if(op!=' ')
            {
                a = double.Parse(problem.Split(op)[0]);
                b = Math.Sqrt(double.Parse(problem.Split(op)[1]));
                calculation();

            }
            else
            {
                a = Math.Sqrt(double.Parse(inputBox.Text));
                inputBox.Text = Convert.ToString(a);
                problem = Convert.ToString(a);
            }
            
        }

        private void reverseNum_Click(object sender, EventArgs e)
        {
            if (op != ' ')
            {
                a = double.Parse(problem.Split(op)[0]);
                b = 1/(double.Parse(problem.Split(op)[1]));
                calculation();

            }
            else
            {
                a = 1/(double.Parse(inputBox.Text));
                inputBox.Text = Convert.ToString(a);
                problem = Convert.ToString(a);
            }
        }

        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void plusMinus_Click(object sender, EventArgs e)
        {
            problem = problem.Split(op)[0]+op;
            string s = "";
            if (inputBox.Text[0] == '-')
            {                
                for(int i = 1; i < inputBox.Text.Length; i++)
                {
                    s += inputBox.Text[i];
                }
                inputBox.Text = s;
            }
            else
            {
                s += '-';
                for(int i = 0; i < inputBox.Text.Length; i++)
                {
                    s += inputBox.Text[i];
                }
                inputBox.Text = s;
            }
            problem += s;
        }
    }
}
