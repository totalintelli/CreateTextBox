using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateTextBox
{
    public partial class Form1 : Form
    {
        TextBox txtBox1 = new TextBox();
        TextBox txtBox2 = new TextBox();
        Button btn1 = new Button();
        Memory memory = new Memory();
        Label lbl1 = new Label();
        DataGridView dgv1 = new DataGridView();
        GroupBox gb1 = new GroupBox();
        NumericUpDown nud1 = new NumericUpDown();

        public Form1()
        {
            InitializeComponent();

            // 텍스트 박스 1
            MakeControl(txtBox1, 10, 1, 100, 20);
            CreateTxtBoxEvent(txtBox1 , Entereds.EnteredLeft );

            // 텍스트 박스 2
            MakeControl(txtBox2, 180, 1, 70, 20);
            CreateTxtBoxEvent(txtBox2 , Entereds.EnteredRight);

            // 버튼
            MakeControl(btn1, 110, 0, 70, 20);
            CreateBtn1Event(btn1);

            // 라벨
            MakeControl(lbl1, 10, 30, 100, 20, "Label");

            #region 그룹 박스 만들기
            // Nemeric Up Down
            MakeGb(gb1, nud1, 250, 5);

            // 데이터 그리드 뷰
            MakeGb(gb1, dgv1, 30, 100, 200, 50); 
            #endregion

            // 만든 그룹 박스를 폼에 붙이기
            MakeControl(gb1, 10, 60, 290, 200, "표");

        }

        /// <summary>
        /// 컨트롤들을 만든다.
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="locationX"></param>
        /// <param name="locationY"></param>
        /// <param name="width"></param>
        /// <param name="headerText"></param>
        private void MakeControl(object control, int locationX, int locationY, int width = 0, int height = 0, string headerText = "")
        {
            Type lblType = typeof(Label); // 라벨 타입
            Type txtType = typeof(TextBox); // 텍스트 박스 타입 
            Type btnType = typeof(Button); // 버튼 타입
            Type dgvType = typeof(DataGridView); // 데이터 그리드 뷰 타입
            Type gbType = typeof(GroupBox); // 그룹 박스 타입 
            Type nudType = typeof(NumericUpDown); // Numeric Up Down 타입
            TableLayoutPanel tlp = new TableLayoutPanel();

            if (control.GetType() == lblType)
            {
                Label label = control as Label;

                // 라벨의 위치를 정한다.
                label.Location = new Point(locationX, locationY);

                // 라벨의 너비를 정한다.
                label.Width = width;

                // 라벨의 높이를 정한다.
                label.Height = height;

                // 라벨의 텍스트를 정한다. 
                label.Text = headerText;

                // 라벨를 추가한다. 
                tlp.Controls.Add(label);
            }
            else if (control.GetType() == txtType)
            {
                TextBox txtBox = control as TextBox;

                // 텍스트 박스의 위치를 정한다.
                txtBox.Location = new Point(locationX, locationY);

                // 텍스트 박스의 너비를 정한다.
                txtBox.Width = width;

                // 텍스트 박스의 높이를 정한다.
                txtBox.Height = height;

                // 텍스트 박스의 헤더를 정한다.
                txtBox.Text = headerText;

                // 텍스트 박스를 추가한다. 
                tlp.Controls.Add(txtBox);
            }
            else if (control.GetType() == btnType)
            {
                Button btn = control as Button;

                // 버튼의 위치를 정한다.
                btn.Location = new Point(locationX, locationY);

                // 버튼의 너비를 정한다.
                btn.Width = width;

                // 버튼의 높이를 정한다.
                btn.Height = height;

                // 버튼의 텍스트를 정한다. 
                btn.Text = "→";

                // 버튼를 추가한다. 
                tlp.Controls.Add(btn);
            }
            else if (control.GetType() == dgvType)
            {
                DataGridView dgv = control as DataGridView;

                // 데이터 그리드 뷰의 위치를 정한다.
                dgv.Location = new Point(locationX, locationY);

                // 데이터 그리드 뷰의 너비를 정한다.
                dgv.Width = width;

                // 데이터 그리드 뷰의 높이를 정한다.
                dgv.Height = height;

                // 데이터 그리드 뷰를 추가한다.
                tlp.Controls.Add(dgv);
            }
            else if (control.GetType() == gbType)
            {
                GroupBox gb = control as GroupBox;

                // 그룹 박스의 위치를 정한다.
                gb.Location = new Point(locationX, locationY);

                // 그룹 박스의 너비를 정한다.
                gb.Width = width;

                // 그룹 박스의 높이를 정한다.
                gb.Height = height;

                // 그룹 박스를 추가한다. 
                tlp.Controls.Add(gb);
            }
            else if (control.GetType() == nudType)
            {
                NumericUpDown nud = control as NumericUpDown;

                // Numeric Up Down의 위치를 정한다.
                nud.Location = new Point(locationX, locationY);

                nud.Dock = DockStyle.Fill;

                // Numeric Up Down을 추가한다.
                tlp.Controls.Add(nud);
            }

            // 테이블 레이아웃을 폼에 추가한다.
            tlp.Dock = DockStyle.Fill;
            this.Controls.Add(tlp);
        }

        /// <summary>
        ///  데이터 그리드뷰와 라벨과 Numeric Up Down과 텍스트 박스가 있는 그룹 박스를 만든다. 
        /// </summary>
        /// <param name="control">데이터 그리드 뷰나 라벨이나 Numeric Up Down이나 텍스트 박스</param>
        /// <param name="locationX">컨트롤의 X 좌표</param>
        /// <param name="locationY">컨트롤의 Y 좌표</param>
        /// <param name="width"> 컨트롤의 너비</param>
        /// <param name="height">컨트롤의 높이 </param>
        /// <param name="headerText">컨트롤의 헤더 글자</param>
        private void MakeGb(GroupBox gb, object control, int locationX, int locationY, int width = 0, int height = 0, string headerText = "")
        {
            Type lblType = typeof(Label); // 라벨 타입
            Type txtType = typeof(TextBox); // 텍스트 박스 타입 
            Type dgvType = typeof(DataGridView); // 데이터 그리드 뷰 타입
            Type nudType = typeof(NumericUpDown); // Numeric Up Down 타입
            TableLayoutPanel tlp = new TableLayoutPanel(); // Table Layout Panel

            if (control.GetType() == lblType)
            {
                Label label = control as Label;

                // 라벨의 위치를 정한다.
                label.Location = new Point(locationX, locationY);

                // 라벨의 너비를 정한다.
                label.Width = width;

                // 라벨의 높이를 정한다.
                label.Height = height;

                // 라벨의 텍스트를 정한다. 
                label.Text = headerText;

                // 라벨를 추가한다. 
                gb.Controls.Add(label);
            }

            if (control.GetType() == txtType)
            {
                TextBox txtBox = control as TextBox;

                // 텍스트 박스의 위치를 정한다.
                txtBox.Location = new Point(locationX, locationY);

                // 텍스트 박스의 너비를 정한다.
                txtBox.Width = width;

                // 텍스트 박스의 높이를 정한다.
                txtBox.Height = height;

                // 텍스트 박스의 헤더를 정한다.
                txtBox.Text = headerText;

                // 텍스트 박스를 추가한다. 
                gb.Controls.Add(txtBox);
            }

            if (control.GetType() == dgvType)
            {
                DataGridView dgv = control as DataGridView;

                // 데이터 그리드 뷰의 위치를 정한다.
                dgv.Location = new Point(locationX, locationY);

                // 데이터 그리드 뷰의 너비를 정한다.
                dgv.Width = width;

                // 데이터 그리드 뷰의 높이를 정한다.
                dgv.Height = height;

                dgv.Dock = DockStyle.Fill;

                // 데이터 그리드 뷰를 추가한다.
                gb.Controls.Add(dgv);
            }

            if (control.GetType() == nudType)
            {
                NumericUpDown nud = control as NumericUpDown;

                // Numeric Up Down의 위치를 정한다.
                nud.Location = new Point(locationX, locationY);

                // Numeric Up Down을 추가한다.
                gb.Controls.Add(nud);
            }
        }

        #region 버튼
        private void Btn1_MouseClick(object sender, MouseEventArgs e)
        {
            txtBox2.Text = txtBox1.Text;
            txtBox1.Text = "";
        }

        /// <summary>
        /// 버튼의 이벤트를 만든다.
        /// </summary>
        /// <param name="btn"></param>
        private void CreateBtn1Event(Button btn)
        {
            btn.MouseClick += Btn1_MouseClick;
        }
        #endregion

        #region 텍스트 박스

        enum Entereds
        {
            EnteredRight,
            EnteredLeft,
        }


        /// <summary>
        /// 텍스트 박스 1의 입력 이벤트를 정한다.
        /// </summary>
        /// <param name="Value"></param>
        private void CreateTxtBoxEvent(TextBox Value , Entereds Type)
        {
            // 텍스트 박스 입력 이벤트를 정한다. 
            Value.Tag = Type;
            Value.TextChanged += TxtBox1_TextChanged;
        }
   

        /// 텍스트를 입력하면 입력한 텍스트를 저장한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textValue = (TextBox)sender;

            if (textValue != null)
            {
                Entereds Etype = (Entereds)textValue.Tag;

                string Result = "";
                switch (Etype)
                {
                    case Entereds.EnteredRight:
                        {
                            Result = memory.EnteredRightText = textValue.Text; 
                            break;
                        }
                    case Entereds.EnteredLeft:
                        {
                            Result = memory.EnteredLeftText = textValue.Text;
                            break;
                        }
                        
                    default:
                        break;
                }

                // 메시지를 출력한다. 
                MessageBox.Show(Result + "를 입력했습니다.");
            }
        } 
        #endregion
    }

    public class Memory
    {
        // 필드
        private string m_EnteredLeftText; // 왼쪽에 입력한 글자
        private string m_EnteredRightText; // 오른쪽에 입력한 글자

        // 속성
        public string EnteredLeftText
        {
            get { return this.m_EnteredLeftText; }
            set
            {
                if (this.m_EnteredLeftText != value)
                {
                    this.m_EnteredLeftText = value;
                }
            }
        } 

        public string EnteredRightText
        {
            get { return this.m_EnteredRightText; }
            set
            {
                if (this.m_EnteredRightText != value)
                {
                    this.m_EnteredRightText = value;
                }
            }
        }
    }
}
