using System;
using System.Globalization;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Test
{
    public partial class frmWeek : Form
    {
        //Khai báo biến toàn cục 

        public frmWeek()
        {
            InitializeComponent();
        }

        public void WeekOfMonth(DateTime a)
        {
            string day = a.DayOfWeek.ToString();
            int year = a.Year;
            int mouth = a.Month;
            int plag = 0;
            DateTime dtx = new DateTime(year, mouth + 1, 1);
            TimeSpan ax = new TimeSpan(-1);
            TimeSpan axs = new TimeSpan(1);
            DateTime cuoithang = dtx.Add(ax);

            string text = "";
            switch (day)
            {
                case "Monday":
                    plag = 2;
                    break;
                case "Tuesday":
                    plag = 3;
                    break;
                case "Wednesday":
                    plag = 4;
                    break;
                case "Thursday":
                    plag = 5;
                    break;
                case "Friday":
                    plag = 6;
                    break;
                case "Saturday":
                    plag = 7;
                    break;
                default:
                    plag = 1;
                    break;
            }
            int dem = 0;
            int ngay = 0;
            for (int i = a.Day; i <= cuoithang.Day; i++)
            {
                DateTime dti = new DateTime(year, mouth, i);
                int wk = GetWeekOfMonth(dti);
                if (wk == 1)
                {
                    text += String.Format(@"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = plag; j <= 7; j++)
                    {
                        dem++;
                        text += String.Format(@"{0}    ", dem);
                    }
                    i += dem - 1;
                    ngay = i;
                }
                else if (wk == 2)
                {
                    text += String.Format(Environment.NewLine + @"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = i; j <= ngay + 7; j++)
                    {
                        text += String.Format(@"{0}    ", j);
                        dem++;
                    }
                    i += dem - 1;
                    ngay = i;
                }
                else if (wk == 3)
                {
                    text += String.Format(Environment.NewLine + @"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = i; j <= ngay + 7; j++)
                    {
                        text += String.Format(@"{0}    ", j);
                        dem++;
                    }
                    i += dem - 1;
                    ngay = i;
                }
                else if (wk == 4)
                {
                    text += String.Format(Environment.NewLine + @"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = i; j <= ngay + 7; j++)
                    {
                        text += String.Format(@"{0}    ", j);
                        dem++;
                    }
                    i += dem - 1;
                    ngay = i;
                }
                else if (wk == 5)
                {
                    text += String.Format(Environment.NewLine + @"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = i; j <= ngay + 7; j++)
                    {
                        text += String.Format(@"{0}    ", j);
                        dem++;
                        if ((i + dem) > cuoithang.Day)
                            break;
                    }
                    i += dem - 1;
                    ngay = i;
                }
                else if (wk == 6)
                {
                    text += String.Format(Environment.NewLine + @"Tuần {0} " + Environment.NewLine, wk);
                    dem = 0;
                    for (int j = i; j <= ngay + 7; j++)
                    {
                        text += String.Format(@"{0}    ", j);
                        dem++;
                        if ((i + dem) > cuoithang.Day)
                            break;
                    }
                    i += dem - 1;
                    ngay = i;
                }
            }
            richTextBox1.Text = text.ToString();
        }
        public static int GetWeekOfMonth(DateTime date)
        {
            DateTime beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                date = date.AddDays(1);

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(dtpBegindate.Value.Year, dtpBegindate.Value.Month, 1);
            WeekOfMonth(dt);
        }
    }
}
