// NBTtag作成コ\u30fcド.Form1
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class Form1 : Form
{
	private IContainer components = null;

	private ListView listView1;

	private NumericUpDown numericUpDown1;

	private GroupBox groupBox1;

	private NumericUpDown numericUpDown2;

	private Label label2;

	private Label label1;

	private Button button1;

	private Button button2;

	private GroupBox groupBox2;

	private CheckBox checkBox5;

	private CheckBox checkBox4;

	private CheckBox checkBox3;

	private CheckBox checkBox2;

	private CheckBox checkBox1;

	private RichTextBox richTextBox1;

	private Button button3;

	private Button button4;

	private GroupBox groupBox3;

	private Label label4;

	private Label label3;

	private ListView listView2;

	private Button button5;

	private NumericUpDown numericUpDown4;

	private NumericUpDown numericUpDown3;

	private GroupBox groupBox4;

	private ListView listView3;

	private NumericUpDown numericUpDown7;

	private NumericUpDown numericUpDown6;

	private NumericUpDown numericUpDown5;

	private Button button6;

	private Label label7;

	private Label label6;

	private Label label5;

	private GroupBox groupBox5;

	private TextBox textBox1;

	private Label label11;

	private Panel panel1;

	private NumericUpDown numericUpDown10;

	private Label label10;

	private Label label9;

	private Label label8;

	private NumericUpDown numericUpDown8;

	private CheckBox checkBox8;

	private CheckBox checkBox7;

	private CheckBox checkBox6;

	private Button button7;

	private Button button8;

	private NumericUpDown numericUpDown9;

	private Label label12;

	private Label label13;

	private ComboBox comboBox1;

	private GroupBox groupBox6;

	private NumericUpDown numericUpDown11;

	private NumericUpDown numericUpDown12;

	private Label label14;

	private Label label15;

	private NumericUpDown numericUpDown15;

	private Label label17;

	private NumericUpDown numericUpDown14;

	private Label label16;

	private NumericUpDown numericUpDown13;

	private Button button9;

	private Button button10;

	private Button button11;

	private Button button12;

	public Form1()
	{
		InitializeComponent();
	}

	private static string hexvalue(int Itemhexvalue)
	{
		if (Itemhexvalue < 0)
		{
			return Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 16)
		{
			return "0000000" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 256)
		{
			return "000000" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 4096)
		{
			return "00000" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 65536)
		{
			return "0000" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 1048576)
		{
			return "000" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 16777216)
		{
			return "00" + Convert.ToString(Itemhexvalue, 16);
		}
		if (Itemhexvalue < 268435456)
		{
			return "0" + Convert.ToString(Itemhexvalue, 16);
		}
		return Convert.ToString(Itemhexvalue, 16) ?? "";
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		int red = (int)numericUpDown8.Value;
		int green = (int)numericUpDown9.Value;
		int blue = (int)numericUpDown10.Value;
		Color color = Color.FromArgb(red, green, blue);
		panel1.BackColor = color;
		string text = ColorTranslator.ToHtml(color);
		textBox1.Text = text;
		listView1.View = View.Details;
		listView1.Columns.Add("ID");
		listView1.Columns.Add("lvl");
		listView2.View = View.Details;
		listView2.Columns.Add("ID");
		listView2.Columns.Add("Amount");
		listView3.View = View.Details;
		listView3.Columns.Add("ID");
		listView3.Columns.Add("Amplifler");
		listView3.Columns.Add("Duration");
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		richTextBox1.ResetText();
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		if (richTextBox1.Text.Length == 0)
		{
			MessageBox.Show("error");
		}
		else
		{
			Clipboard.SetText(richTextBox1.Text);
		}
	}

	private void NumericUpDown8_ValueChanged(object sender, EventArgs e)
	{
		int red = (int)numericUpDown8.Value;
		int green = (int)numericUpDown9.Value;
		int blue = (int)numericUpDown10.Value;
		Color color = Color.FromArgb(red, green, blue);
		panel1.BackColor = color;
		string text = ColorTranslator.ToHtml(color);
		textBox1.Text = text;
	}

	private void NumericUpDown9_ValueChanged(object sender, EventArgs e)
	{
		int red = (int)numericUpDown8.Value;
		int green = (int)numericUpDown9.Value;
		int blue = (int)numericUpDown10.Value;
		Color color = Color.FromArgb(red, green, blue);
		panel1.BackColor = color;
		string text = ColorTranslator.ToHtml(color);
		textBox1.Text = text;
	}

	private void NumericUpDown10_ValueChanged(object sender, EventArgs e)
	{
		int red = (int)numericUpDown8.Value;
		int green = (int)numericUpDown9.Value;
		int blue = (int)numericUpDown10.Value;
		Color color = Color.FromArgb(red, green, blue);
		panel1.BackColor = color;
		string text = ColorTranslator.ToHtml(color);
		textBox1.Text = text;
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox1.Checked)
		{
			groupBox1.Enabled = false;
		}
		else
		{
			groupBox1.Enabled = true;
		}
	}

	private void CheckBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox3.Checked)
		{
			groupBox4.Enabled = false;
		}
		else
		{
			groupBox4.Enabled = true;
		}
	}

	private void GroupBox2_Enter(object sender, EventArgs e)
	{
	}

	private void CheckBox5_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox5.Checked)
		{
			groupBox5.Enabled = false;
		}
		else
		{
			groupBox5.Enabled = true;
		}
	}

	private void Button7_Click(object sender, EventArgs e)
	{
		Process.Start("https://www.youtube.com/channel/UCXRPjFwZ_IBuRsbiJ5GlXdg/feed");
	}

	private void Button8_Click(object sender, EventArgs e)
	{
		Process.Start("https://www.youtube.com/channel/UCqI3x47OlUfndU3b9VhAwwQ?view_as=subscriber");
	}

	private void CheckBox6_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox6.Checked)
		{
			checkBox7.Enabled = true;
		}
		else
		{
			checkBox7.Enabled = false;
		}
	}

	private void CheckBox7_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox7.Checked)
		{
			checkBox6.Enabled = true;
		}
		else
		{
			checkBox6.Enabled = false;
		}
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		richTextBox1.ResetText();
		int num13 = 301989888;
		string text38 = " ";
		int red = (int)numericUpDown8.Value;
		int green = (int)numericUpDown9.Value;
		int blue = (int)numericUpDown10.Value;
		Color c = Color.FromArgb(red, green, blue);
		string text39 = ColorTranslator.ToHtml(c);
		if (checkBox1.Checked)
		{
			if (listView1.CheckedItems.Count == 0)
			{
				MessageBox.Show("Check the enchantment listView");
				return;
			}
			if (listView1.CheckedItems.Count > 30)
			{
				MessageBox.Show("Enchant listView has too many checks" + Environment.NewLine + "The maximum number is 30");
				return;
			}
		}
		else if (checkBox2.Checked)
		{
			if (listView2.CheckedItems.Count == 0)
			{
				MessageBox.Show("Please check the listView of the potion");
				return;
			}
			if (listView2.CheckedItems.Count > 30)
			{
				MessageBox.Show("Too many checks in potion listView" + Environment.NewLine + "The maximum number is 30");
				return;
			}
		}
		else if (checkBox3.Checked)
		{
			if (listView3.CheckedItems.Count == 0)
			{
				MessageBox.Show("Check the status listView");
				return;
			}
			if (listView3.CheckedItems.Count > 30)
			{
				MessageBox.Show("Too many checks in listView for status" + Environment.NewLine + "The maximum number is 30");
				return;
			}
		}
		else if (!checkBox4.Checked)
		{
			if (!checkBox5.Checked)
			{
				MessageBox.Show("error");
				return;
			}
			if (!checkBox6.Checked && !checkBox7.Checked)
			{
				richTextBox1.ResetText();
				MessageBox.Show("Check Map Color or Armor Color");
				return;
			}
		}
		if (comboBox1.SelectedIndex == 0)
		{
			text38 = "10a0a6c0";
		}
		else if (comboBox1.SelectedIndex == 1)
		{
			text38 = "10a0a6d0";
		}
		else if (comboBox1.SelectedIndex == 2)
		{
			text38 = "10a0a700";
		}
		else if (comboBox1.SelectedIndex == 3)
		{
			text38 = "10a0a710";
		}
		else if (comboBox1.SelectedIndex == 4)
		{
			text38 = "10a0a720";
		}
		else if (comboBox1.SelectedIndex == 5)
		{
			text38 = "10a0a770";
		}
		else if (comboBox1.SelectedIndex == -1)
		{
			MessageBox.Show("Please select the place to install in the creative column");
			return;
		}
		string text37 = hexvalue((int)numericUpDown13.Value * 4);
		string text36 = hexvalue((int)numericUpDown12.Value * 4);
		string text35 = hexvalue((int)numericUpDown15.Value);
		string text34 = hexvalue((int)numericUpDown14.Value);
		richTextBox1.Text = richTextBox1.Text + "30000000 109df84c" + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "10120001 " + text37 + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "30000000 " + text38 + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "31000000 " + text36 + Environment.NewLine + "30100000 00000000" + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "11120001 00000014" + Environment.NewLine + "0012000c " + text35 + Environment.NewLine + "00120020 " + text34 + Environment.NewLine + "00120018 " + Convert.ToString(num13, 16) + Environment.NewLine + "d0000000 deadcafe" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13, 16) + Environment.NewLine + "1058fa54 00a8a598" + Environment.NewLine + "00000011 00000001" + Environment.NewLine + "3f800000 00000011" + Environment.NewLine + Convert.ToString(num13 + 48, 16) + " 000000FF" + Environment.NewLine + "30000000 " + Convert.ToString(num13 + 24, 16) + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "00120044 " + Convert.ToString(num13 + 212, 16) + Environment.NewLine + "01000044 " + Convert.ToString(num13 + 160, 16) + Environment.NewLine + "1056415C ";
		if (checkBox4.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "01000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
		}
		else
		{
			richTextBox1.Text = richTextBox1.Text + "00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
		}
		richTextBox1.Text = richTextBox1.Text + "11B0D430 0000afb8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 224, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 160, 16) + " " + Convert.ToString(num13 + 308, 16) + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine + "01000018 " + Convert.ToString(num13 + 224, 16) + Environment.NewLine + "0055006E 00620072" + Environment.NewLine + "00650061 006B0061" + Environment.NewLine + "0062006C 00650000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000030 " + Convert.ToString(num13 + 272, 16) + Environment.NewLine + "11B0D430 0000AFB8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 320, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 4096, 16) + " " + Convert.ToString(num13 + 388, 16) + Environment.NewLine + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000014 " + Convert.ToString(num13 + 320, 16) + Environment.NewLine + "00640069 00730070" + Environment.NewLine + "006C0061 00790000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 4096, 16) + Environment.NewLine + "1058fa54 00a8a598" + Environment.NewLine + "00000011 00000001" + Environment.NewLine + "3f800000 00000011" + Environment.NewLine + Convert.ToString(num13 + 48 + 4096, 16) + " 000000FF" + Environment.NewLine + "30000000 " + Convert.ToString(num13 + 24 + 4096, 16) + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "00120044 " + Convert.ToString(num13 + 212 + 4096, 16) + Environment.NewLine + "01000044 " + Convert.ToString(num13 + 160 + 4096, 16) + Environment.NewLine + "1065993C 00" + text39.Substring(1, 6) + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "11B0D430 0000afb8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 224 + 4096, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 160 + 4096, 16) + " 00000000" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		if (checkBox7.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 224 + 4096, 16) + Environment.NewLine + "0063006F 006C006F" + Environment.NewLine + "00720000 000000ff" + Environment.NewLine;
		}
		if (checkBox6.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "01000014 " + Convert.ToString(num13 + 224 + 4096, 16) + Environment.NewLine + "004D0061 00700043" + Environment.NewLine + "006F006C 006F0072" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		}
		if (!checkBox5.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "01000016 " + Convert.ToString(num13 + 224 + 4096, 16) + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		}
		richTextBox1.Text = richTextBox1.Text + "01000030 " + Convert.ToString(num13 + 352, 16) + Environment.NewLine + "11B0D430 0000AFB8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 400, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 8192, 16) + " " + Convert.ToString(num13 + 468, 16) + Environment.NewLine + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000014 " + Convert.ToString(num13 + 400, 16) + Environment.NewLine + "0065006E 00630068" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000030 " + Convert.ToString(num13 + 432, 16) + Environment.NewLine + "11B0D430 0000AFB8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 480, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 20480, 16) + " " + Convert.ToString(num13 + 596, 16) + Environment.NewLine + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000026 " + Convert.ToString(num13 + 480, 16) + Environment.NewLine + "00410074 00740072" + Environment.NewLine + "00690062 00750074" + Environment.NewLine + "0065004D 006F0064" + Environment.NewLine + "00690066 00690065" + Environment.NewLine + "00720073 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "01000030 " + Convert.ToString(num13 + 560, 16) + Environment.NewLine + "11B0D430 0000AFB8" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 608, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 40960, 16) + " 00000000" + Environment.NewLine + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		richTextBox1.Text = richTextBox1.Text + "0100002c " + Convert.ToString(num13 + 608, 16) + Environment.NewLine + "00430075 00730074" + Environment.NewLine + "006F006D 0050006F" + Environment.NewLine + "00740069 006F006E" + Environment.NewLine + "00450066 00660065" + Environment.NewLine + "00630074 00730000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		if (checkBox1.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 8192, 16) + Environment.NewLine + "1067DAF0 00000000" + Environment.NewLine + Convert.ToString(num13 + 8240, 16) + " " + Convert.ToString(num13 + 8240 + listView1.CheckedItems.Count * 4, 16) + Environment.NewLine + Convert.ToString(num13 + 8240 + listView1.CheckedItems.Count * 4, 16) + " 0A000000" + Environment.NewLine + "00000000 000000FF" + Environment.NewLine;
			int k = 0;
			int num12 = 0;
			int num11 = 0;
			string text33 = "";
			for (; k < listView1.Items.Count; k++)
			{
				if (listView1.Items[k].Checked)
				{
					text33 = ((num12 % 2 != 0) ? (text33 + Convert.ToString(num13 + 8496 + num12 * 320, 16) + Environment.NewLine) : (text33 + Convert.ToString(num13 + 8496 + num12 * 320, 16) + " "));
					string text30 = hexvalue(int.Parse(listView1.Items[k].SubItems[1].Text));
					string text29 = hexvalue(int.Parse(listView1.Items[k].SubItems[0].Text));
					richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 8496 + num11, 16) + Environment.NewLine + "1058fa54 00a8a598" + Environment.NewLine + "00000011 00000001" + Environment.NewLine + "3f800000 00000011" + Environment.NewLine + Convert.ToString(num13 + 48 + 8496 + num11, 16) + " 000000ff" + Environment.NewLine + "30000000 " + Convert.ToString(num13 + 24 + 8496 + num11, 16) + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "00120044 " + Convert.ToString(num13 + 212 + 8496 + num11, 16) + Environment.NewLine + "01000044 " + Convert.ToString(num13 + 160 + 8496 + num11, 16) + Environment.NewLine + "10748CF8 " + text30.Substring(4, 4) + "0000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 8720 + num11, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 160 + 8496 + num11, 16) + " " + Convert.ToString(num13 + 8788 + num11, 16) + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 8720 + num11, 16) + Environment.NewLine + "006C0076 006C0000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000044 " + Convert.ToString(num13 + 8736 + num11, 16) + Environment.NewLine + "10748CF8 " + text29.Substring(4, 4) + "0000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 8800 + num11, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 8736 + num11, 16) + " 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 8800 + num11, 16) + Environment.NewLine + "00690064 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					num11 += 320;
					num12++;
				}
			}
			if (num12 % 2 == 1)
			{
				string text32 = hexvalue(listView1.CheckedItems.Count * 4 + 8);
				richTextBox1.Text = richTextBox1.Text + "0100" + text32.Substring(4, 4) + " " + Convert.ToString(num13 + 8240, 16) + Environment.NewLine + text33 + "00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
			}
			else
			{
				string text31 = hexvalue(listView1.CheckedItems.Count * 4 + 4);
				richTextBox1.Text = richTextBox1.Text + "0100" + text31.Substring(4, 4) + " " + Convert.ToString(num13 + 8240, 16) + Environment.NewLine + text33 + "00000000 000000ff" + Environment.NewLine;
			}
		}
		else
		{
			richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 8192, 16) + Environment.NewLine + "1065993C 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		}
		if (checkBox2.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 20480, 16) + Environment.NewLine + "1067DAF0 00000000" + Environment.NewLine + Convert.ToString(num13 + 20528, 16) + " " + Convert.ToString(num13 + 20528 + listView2.CheckedItems.Count * 4, 16) + Environment.NewLine + Convert.ToString(num13 + 20528 + listView2.CheckedItems.Count * 4, 16) + " 0A000000" + Environment.NewLine + "00000000 000000FF" + Environment.NewLine;
			int j = 0;
			int num10 = 0;
			int num9 = 0;
			string text28 = "";
			for (; j < listView2.Items.Count; j++)
			{
				if (listView2.Items[j].Checked)
				{
					text28 = ((num10 % 2 != 0) ? (text28 + Convert.ToString(num13 + 20784 + num10 * 336, 16) + Environment.NewLine) : (text28 + Convert.ToString(num13 + 20784 + num10 * 336, 16) + " "));
					string text25 = hexvalue(int.Parse(listView2.Items[j].SubItems[0].Text));
					double value3 = double.Parse(listView2.Items[j].SubItems[1].Text);
					byte[] bytes = BitConverter.GetBytes(value3);
					string[] value2 = bytes.Select(delegate(byte a)
					{
						byte b = a;
						return b.ToString("X2");
					}).Reverse().ToArray();
					richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 20784 + num9, 16) + Environment.NewLine + "1058fa54 00a8a598" + Environment.NewLine + "00000011 00000001" + Environment.NewLine + "3f800000 00000011" + Environment.NewLine + Convert.ToString(num13 + 48 + 20784 + num9, 16) + " 000000ff" + Environment.NewLine + "30000000 " + Convert.ToString(num13 + 24 + 20784 + num9, 16) + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "00120044 " + Convert.ToString(num13 + 212 + 20784 + num9, 16) + Environment.NewLine + "01000044 " + Convert.ToString(num13 + 160 + 20784 + num9, 16) + Environment.NewLine + "1065993C " + text25 + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 21008 + num9, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 160 + 20784 + num9, 16) + " " + Convert.ToString(num13 + 21076 + num9, 16) + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 21008 + num9, 16) + Environment.NewLine + "00490044 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000044 " + Convert.ToString(num13 + 21024 + num9, 16) + Environment.NewLine + "105C76B4 00000000" + Environment.NewLine + string.Join("", value2).Substring(0, 8) + " 00000000" + Environment.NewLine + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 21088 + num9, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 21024 + num9, 16) + " 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "0100000e " + Convert.ToString(num13 + 21088 + num9, 16) + Environment.NewLine + "0041006D 006F0075" + Environment.NewLine + "006E0074 000000ff" + Environment.NewLine;
					num9 += 336;
					num10++;
				}
			}
			if (num10 % 2 == 1)
			{
				string text27 = hexvalue(listView2.CheckedItems.Count * 4 + 8);
				richTextBox1.Text = richTextBox1.Text + "0100" + text27.Substring(4, 4) + " " + Convert.ToString(num13 + 20528, 16) + Environment.NewLine + text28 + "00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
			}
			else
			{
				string text26 = hexvalue(listView2.CheckedItems.Count * 4 + 4);
				richTextBox1.Text = richTextBox1.Text + "0100" + text26.Substring(4, 4) + " " + Convert.ToString(num13 + 20528, 16) + Environment.NewLine + text28 + "00000000 000000ff" + Environment.NewLine;
			}
		}
		else
		{
			richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 20480, 16) + Environment.NewLine + "1065993C 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		}
		if (checkBox3.Checked)
		{
			richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 40960, 16) + Environment.NewLine + "1067DAF0 00000000" + Environment.NewLine + Convert.ToString(num13 + 41008, 16) + " " + Convert.ToString(num13 + 41008 + listView3.CheckedItems.Count * 4, 16) + Environment.NewLine + Convert.ToString(num13 + 41008 + listView3.CheckedItems.Count * 4, 16) + " 0A000000" + Environment.NewLine + "00000000 000000FF" + Environment.NewLine;
			int i = 0;
			int num8 = 0;
			int num7 = 0;
			string text24 = "";
			for (; i < listView3.Items.Count; i++)
			{
				if (listView3.Items[i].Checked)
				{
					text24 = ((num8 % 2 != 0) ? (text24 + Convert.ToString(num13 + 41264 + num8 * 464, 16) + Environment.NewLine) : (text24 + Convert.ToString(num13 + 41264 + num8 * 464, 16) + " "));
					string text21 = hexvalue(int.Parse(listView3.Items[i].SubItems[1].Text));
					string text20 = hexvalue(int.Parse(listView3.Items[i].SubItems[0].Text));
					string text19 = hexvalue(int.Parse(listView3.Items[i].SubItems[2].Text));
					richTextBox1.Text = richTextBox1.Text + "0100001c " + Convert.ToString(num13 + 41264 + num7, 16) + Environment.NewLine + "1058fa54 00a8a598" + Environment.NewLine + "00000011 00000001" + Environment.NewLine + "3f800000 00000011" + Environment.NewLine + Convert.ToString(num13 + 41312 + num7, 16) + " 000000ff" + Environment.NewLine + "30000000 " + Convert.ToString(num13 + 24 + 41264 + num7, 16) + Environment.NewLine + "10000000 50000000" + Environment.NewLine + "00120044 " + Convert.ToString(num13 + 212 + 41264 + num7, 16) + Environment.NewLine + "01000044 " + Convert.ToString(num13 + 160 + 41264 + num7, 16) + Environment.NewLine + "1065993C " + text20 + Environment.NewLine + "00000000 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 41488 + num7, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 160 + 41264 + num7, 16) + " " + Convert.ToString(num13 + 41556 + num7, 16) + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 41488 + num7, 16) + Environment.NewLine + "00490064 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000044 " + Convert.ToString(num13 + 41504 + num7, 16) + Environment.NewLine + "1065993C " + text19 + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 41568 + num7, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 41504 + num7, 16) + " " + Convert.ToString(num13 + 41668 + num7, 16) + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000014 " + Convert.ToString(num13 + 41568 + num7, 16) + Environment.NewLine + "00440075 00720061" + Environment.NewLine + "00740069 006F006E" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000044 " + Convert.ToString(num13 + 41616 + num7, 16) + Environment.NewLine + "1065993C " + text21 + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 00000000" + Environment.NewLine + "00000000 00000000" + Environment.NewLine + "11B0D430 " + Convert.ToString(num13 + 41680 + num7, 16) + Environment.NewLine + "00000000 00000017" + Environment.NewLine + Convert.ToString(num13 + 41616 + num7, 16) + " 00000000" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "00000000 0000003b" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
					richTextBox1.Text = richTextBox1.Text + "01000014 " + Convert.ToString(num13 + 41680 + num7, 16) + Environment.NewLine + "0041006D 0070006C" + Environment.NewLine + "00690066 00690065" + Environment.NewLine + "00720000 000000ff" + Environment.NewLine;
					num7 += 464;
					num8++;
				}
			}
			if (num8 % 2 == 1)
			{
				string text23 = hexvalue(listView3.CheckedItems.Count * 4 + 8);
				richTextBox1.Text = richTextBox1.Text + "0100" + text23.Substring(4, 4) + " " + Convert.ToString(num13 + 41008, 16) + Environment.NewLine + text24 + "00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
			}
			else
			{
				string text22 = hexvalue(listView3.CheckedItems.Count * 4 + 4);
				richTextBox1.Text = richTextBox1.Text + "0100" + text22.Substring(4, 4) + " " + Convert.ToString(num13 + 41008, 16) + Environment.NewLine + text24 + "00000000 000000ff" + Environment.NewLine;
			}
		}
		else
		{
			richTextBox1.Text = richTextBox1.Text + "0100000c " + Convert.ToString(num13 + 40960, 16) + Environment.NewLine + "1065993C 00000000" + Environment.NewLine + "00000000 000000ff" + Environment.NewLine;
		}
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (!checkBox2.Checked)
		{
			groupBox3.Enabled = false;
		}
		else
		{
			groupBox3.Enabled = true;
		}
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		ListViewItem listViewItem = listView1.Items.Add(numericUpDown1.Value.ToString());
		listViewItem.SubItems.Add(numericUpDown2.Value.ToString());
		listView1.CheckBoxes = true;
	}

	private void Button5_Click(object sender, EventArgs e)
	{
		ListViewItem listViewItem = listView2.Items.Add(numericUpDown3.Value.ToString());
		listViewItem.SubItems.Add(numericUpDown4.Value.ToString());
		listView2.CheckBoxes = true;
	}

	private void Button6_Click(object sender, EventArgs e)
	{
		ListViewItem listViewItem = listView3.Items.Add(numericUpDown5.Value.ToString());
		listViewItem.SubItems.Add(numericUpDown6.Value.ToString());
		listViewItem.SubItems.Add(numericUpDown7.Value.ToString());
		listView3.CheckBoxes = true;
	}

	private void Label15_Click(object sender, EventArgs e)
	{
	}

	private void Button9_Click(object sender, EventArgs e)
	{
		Process.Start("https://minecraft-ids.grahamedgecombe.com/");
	}

	private void Button10_Click(object sender, EventArgs e)
	{
		Process.Start("https://minecraft-ja.gamepedia.com/エンチャント/ID");
	}

	private void Button11_Click(object sender, EventArgs e)
	{
		Process.Start("https://minecraft-ja.gamepedia.com/ステ\u30fcタス効果/ID");
	}

	private void Button12_Click(object sender, EventArgs e)
	{
		MessageBox.Show("This is made by 少年革命家のんちゃんチャンネル and translated by nt games !\r\n\r\nDon't try to decompile or your PC will be hacked in the next 24 hours (same for your discord account).");
	}

	private void numericUpDown15_ValueChanged(object sender, EventArgs e)
	{
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		listView1 = new System.Windows.Forms.ListView();
		numericUpDown1 = new System.Windows.Forms.NumericUpDown();
		groupBox1 = new System.Windows.Forms.GroupBox();
		numericUpDown2 = new System.Windows.Forms.NumericUpDown();
		label2 = new System.Windows.Forms.Label();
		label1 = new System.Windows.Forms.Label();
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		groupBox2 = new System.Windows.Forms.GroupBox();
		checkBox5 = new System.Windows.Forms.CheckBox();
		checkBox4 = new System.Windows.Forms.CheckBox();
		checkBox3 = new System.Windows.Forms.CheckBox();
		checkBox2 = new System.Windows.Forms.CheckBox();
		checkBox1 = new System.Windows.Forms.CheckBox();
		richTextBox1 = new System.Windows.Forms.RichTextBox();
		button3 = new System.Windows.Forms.Button();
		button4 = new System.Windows.Forms.Button();
		groupBox3 = new System.Windows.Forms.GroupBox();
		numericUpDown4 = new System.Windows.Forms.NumericUpDown();
		numericUpDown3 = new System.Windows.Forms.NumericUpDown();
		label4 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		listView2 = new System.Windows.Forms.ListView();
		button5 = new System.Windows.Forms.Button();
		groupBox4 = new System.Windows.Forms.GroupBox();
		listView3 = new System.Windows.Forms.ListView();
		numericUpDown7 = new System.Windows.Forms.NumericUpDown();
		numericUpDown6 = new System.Windows.Forms.NumericUpDown();
		numericUpDown5 = new System.Windows.Forms.NumericUpDown();
		button6 = new System.Windows.Forms.Button();
		label7 = new System.Windows.Forms.Label();
		label6 = new System.Windows.Forms.Label();
		label5 = new System.Windows.Forms.Label();
		groupBox5 = new System.Windows.Forms.GroupBox();
		numericUpDown11 = new System.Windows.Forms.NumericUpDown();
		numericUpDown9 = new System.Windows.Forms.NumericUpDown();
		textBox1 = new System.Windows.Forms.TextBox();
		label11 = new System.Windows.Forms.Label();
		panel1 = new System.Windows.Forms.Panel();
		numericUpDown10 = new System.Windows.Forms.NumericUpDown();
		label10 = new System.Windows.Forms.Label();
		label9 = new System.Windows.Forms.Label();
		label8 = new System.Windows.Forms.Label();
		numericUpDown8 = new System.Windows.Forms.NumericUpDown();
		checkBox8 = new System.Windows.Forms.CheckBox();
		checkBox7 = new System.Windows.Forms.CheckBox();
		checkBox6 = new System.Windows.Forms.CheckBox();
		numericUpDown15 = new System.Windows.Forms.NumericUpDown();
		numericUpDown12 = new System.Windows.Forms.NumericUpDown();
		button7 = new System.Windows.Forms.Button();
		button8 = new System.Windows.Forms.Button();
		label12 = new System.Windows.Forms.Label();
		label13 = new System.Windows.Forms.Label();
		comboBox1 = new System.Windows.Forms.ComboBox();
		groupBox6 = new System.Windows.Forms.GroupBox();
		label17 = new System.Windows.Forms.Label();
		numericUpDown14 = new System.Windows.Forms.NumericUpDown();
		label16 = new System.Windows.Forms.Label();
		numericUpDown13 = new System.Windows.Forms.NumericUpDown();
		label15 = new System.Windows.Forms.Label();
		label14 = new System.Windows.Forms.Label();
		button9 = new System.Windows.Forms.Button();
		button10 = new System.Windows.Forms.Button();
		button11 = new System.Windows.Forms.Button();
		button12 = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
		groupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
		groupBox2.SuspendLayout();
		groupBox3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
		groupBox4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
		groupBox5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown15).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
		groupBox6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown14).BeginInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown13).BeginInit();
		SuspendLayout();
		listView1.HideSelection = false;
		listView1.Location = new System.Drawing.Point(156, 20);
		listView1.Name = "listView1";
		listView1.Size = new System.Drawing.Size(261, 108);
		listView1.TabIndex = 0;
		listView1.UseCompatibleStateImageBehavior = false;
		numericUpDown1.Location = new System.Drawing.Point(30, 24);
		numericUpDown1.Minimum = new decimal(new int[4]
		{
			32767,
			0,
			0,
			-2147483648
		});
		numericUpDown1.Name = "numericUpDown1";
		numericUpDown1.Size = new System.Drawing.Size(120, 20);
		numericUpDown1.TabIndex = 1;
		groupBox1.Controls.Add(numericUpDown2);
		groupBox1.Controls.Add(label2);
		groupBox1.Controls.Add(label1);
		groupBox1.Controls.Add(button1);
		groupBox1.Controls.Add(numericUpDown1);
		groupBox1.Controls.Add(listView1);
		groupBox1.Enabled = false;
		groupBox1.Location = new System.Drawing.Point(12, 13);
		groupBox1.Name = "groupBox1";
		groupBox1.Size = new System.Drawing.Size(423, 134);
		groupBox1.TabIndex = 2;
		groupBox1.TabStop = false;
		groupBox1.Text = "Enchantment";
		numericUpDown2.Location = new System.Drawing.Point(30, 51);
		numericUpDown2.Maximum = new decimal(new int[4]
		{
			32767,
			0,
			0,
			0
		});
		numericUpDown2.Minimum = new decimal(new int[4]
		{
			32767,
			0,
			0,
			-2147483648
		});
		numericUpDown2.Name = "numericUpDown2";
		numericUpDown2.Size = new System.Drawing.Size(120, 20);
		numericUpDown2.TabIndex = 4;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(9, 54);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(17, 13);
		label2.TabIndex = 4;
		label2.Text = "lvl";
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(7, 26);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(18, 13);
		label1.TabIndex = 3;
		label1.Text = "ID";
		button1.Location = new System.Drawing.Point(6, 103);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(144, 25);
		button1.TabIndex = 2;
		button1.Text = "Add";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(Button1_Click);
		button2.Location = new System.Drawing.Point(781, 450);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(213, 25);
		button2.TabIndex = 3;
		button2.Text = "Generate";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(Button2_Click);
		groupBox2.Controls.Add(checkBox5);
		groupBox2.Controls.Add(checkBox4);
		groupBox2.Controls.Add(checkBox3);
		groupBox2.Controls.Add(checkBox2);
		groupBox2.Controls.Add(checkBox1);
		groupBox2.Location = new System.Drawing.Point(441, 13);
		groupBox2.Name = "groupBox2";
		groupBox2.Size = new System.Drawing.Size(172, 143);
		groupBox2.TabIndex = 4;
		groupBox2.TabStop = false;
		groupBox2.Text = "Who uses it, who doesn't use it";
		groupBox2.Enter += new System.EventHandler(GroupBox2_Enter);
		checkBox5.AutoSize = true;
		checkBox5.Location = new System.Drawing.Point(7, 120);
		checkBox5.Name = "checkBox5";
		checkBox5.Size = new System.Drawing.Size(79, 17);
		checkBox5.TabIndex = 6;
		checkBox5.Text = "Color armor";
		checkBox5.UseVisualStyleBackColor = true;
		checkBox5.CheckedChanged += new System.EventHandler(CheckBox5_CheckedChanged);
		checkBox4.AutoSize = true;
		checkBox4.Location = new System.Drawing.Point(7, 95);
		checkBox4.Name = "checkBox4";
		checkBox4.Size = new System.Drawing.Size(78, 17);
		checkBox4.TabIndex = 5;
		checkBox4.Text = "Endurance";
		checkBox4.UseVisualStyleBackColor = true;
		checkBox3.AutoSize = true;
		checkBox3.Location = new System.Drawing.Point(7, 45);
		checkBox3.Name = "checkBox3";
		checkBox3.Size = new System.Drawing.Size(56, 17);
		checkBox3.TabIndex = 2;
		checkBox3.Text = "Potion";
		checkBox3.UseVisualStyleBackColor = true;
		checkBox3.CheckedChanged += new System.EventHandler(CheckBox3_CheckedChanged);
		checkBox2.AutoSize = true;
		checkBox2.Location = new System.Drawing.Point(7, 70);
		checkBox2.Name = "checkBox2";
		checkBox2.Size = new System.Drawing.Size(56, 17);
		checkBox2.TabIndex = 1;
		checkBox2.Text = "Status";
		checkBox2.UseVisualStyleBackColor = true;
		checkBox2.CheckedChanged += new System.EventHandler(CheckBox2_CheckedChanged);
		checkBox1.AutoSize = true;
		checkBox1.Location = new System.Drawing.Point(7, 20);
		checkBox1.Name = "checkBox1";
		checkBox1.Size = new System.Drawing.Size(89, 17);
		checkBox1.TabIndex = 0;
		checkBox1.Text = "Enchantment";
		checkBox1.UseVisualStyleBackColor = true;
		checkBox1.CheckedChanged += new System.EventHandler(CheckBox1_CheckedChanged);
		richTextBox1.Location = new System.Drawing.Point(781, 13);
		richTextBox1.Name = "richTextBox1";
		richTextBox1.Size = new System.Drawing.Size(213, 367);
		richTextBox1.TabIndex = 5;
		richTextBox1.Text = "";
		button3.Location = new System.Drawing.Point(781, 418);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(213, 25);
		button3.TabIndex = 6;
		button3.Text = "Delect";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(Button3_Click);
		button4.Location = new System.Drawing.Point(781, 387);
		button4.Name = "button4";
		button4.Size = new System.Drawing.Size(213, 25);
		button4.TabIndex = 7;
		button4.Text = "Copy clip board";
		button4.UseVisualStyleBackColor = true;
		button4.Click += new System.EventHandler(Button4_Click);
		groupBox3.Controls.Add(numericUpDown4);
		groupBox3.Controls.Add(numericUpDown3);
		groupBox3.Controls.Add(label4);
		groupBox3.Controls.Add(label3);
		groupBox3.Controls.Add(listView2);
		groupBox3.Controls.Add(button5);
		groupBox3.Enabled = false;
		groupBox3.Location = new System.Drawing.Point(12, 316);
		groupBox3.Name = "groupBox3";
		groupBox3.Size = new System.Drawing.Size(423, 139);
		groupBox3.TabIndex = 8;
		groupBox3.TabStop = false;
		groupBox3.Text = "Status";
		numericUpDown4.DecimalPlaces = 1;
		numericUpDown4.Increment = new decimal(new int[4]
		{
			1,
			0,
			0,
			65536
		});
		numericUpDown4.Location = new System.Drawing.Point(6, 70);
		numericUpDown4.Maximum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			0
		});
		numericUpDown4.Minimum = new decimal(new int[4]
		{
			-1486618625,
			232830643,
			0,
			-2147483648
		});
		numericUpDown4.Name = "numericUpDown4";
		numericUpDown4.Size = new System.Drawing.Size(186, 20);
		numericUpDown4.TabIndex = 9;
		numericUpDown3.Location = new System.Drawing.Point(75, 20);
		numericUpDown3.Maximum = new decimal(new int[4]
		{
			-1486618625,
			232830643,
			0,
			0
		});
		numericUpDown3.Minimum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			-2147483648
		});
		numericUpDown3.Name = "numericUpDown3";
		numericUpDown3.Size = new System.Drawing.Size(120, 20);
		numericUpDown3.TabIndex = 9;
		label4.AutoSize = true;
		label4.Location = new System.Drawing.Point(7, 49);
		label4.Name = "label4";
		label4.Size = new System.Drawing.Size(15, 13);
		label4.TabIndex = 10;
		label4.Text = "id";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(7, 22);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(43, 13);
		label3.TabIndex = 9;
		label3.Text = "Amount";
		listView2.HideSelection = false;
		listView2.Location = new System.Drawing.Point(201, 16);
		listView2.Name = "listView2";
		listView2.Size = new System.Drawing.Size(216, 116);
		listView2.TabIndex = 9;
		listView2.UseCompatibleStateImageBehavior = false;
		button5.Location = new System.Drawing.Point(6, 107);
		button5.Name = "button5";
		button5.Size = new System.Drawing.Size(189, 25);
		button5.TabIndex = 9;
		button5.Text = "Add";
		button5.UseVisualStyleBackColor = true;
		button5.Click += new System.EventHandler(Button5_Click);
		groupBox4.Controls.Add(listView3);
		groupBox4.Controls.Add(numericUpDown7);
		groupBox4.Controls.Add(numericUpDown6);
		groupBox4.Controls.Add(numericUpDown5);
		groupBox4.Controls.Add(button6);
		groupBox4.Controls.Add(label7);
		groupBox4.Controls.Add(label6);
		groupBox4.Controls.Add(label5);
		groupBox4.Enabled = false;
		groupBox4.Location = new System.Drawing.Point(12, 154);
		groupBox4.Name = "groupBox4";
		groupBox4.Size = new System.Drawing.Size(423, 156);
		groupBox4.TabIndex = 9;
		groupBox4.TabStop = false;
		groupBox4.Text = "Potion";
		listView3.HideSelection = false;
		listView3.Location = new System.Drawing.Point(201, 20);
		listView3.Name = "listView3";
		listView3.Size = new System.Drawing.Size(216, 132);
		listView3.TabIndex = 14;
		listView3.UseCompatibleStateImageBehavior = false;
		numericUpDown7.Location = new System.Drawing.Point(75, 75);
		numericUpDown7.Maximum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			0
		});
		numericUpDown7.Minimum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			-2147483648
		});
		numericUpDown7.Name = "numericUpDown7";
		numericUpDown7.Size = new System.Drawing.Size(120, 20);
		numericUpDown7.TabIndex = 13;
		numericUpDown6.Location = new System.Drawing.Point(75, 48);
		numericUpDown6.Maximum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			0
		});
		numericUpDown6.Minimum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			-2147483648
		});
		numericUpDown6.Name = "numericUpDown6";
		numericUpDown6.Size = new System.Drawing.Size(120, 20);
		numericUpDown6.TabIndex = 12;
		numericUpDown5.Location = new System.Drawing.Point(75, 21);
		numericUpDown5.Maximum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			0
		});
		numericUpDown5.Minimum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			-2147483648
		});
		numericUpDown5.Name = "numericUpDown5";
		numericUpDown5.Size = new System.Drawing.Size(120, 20);
		numericUpDown5.TabIndex = 11;
		button6.Location = new System.Drawing.Point(6, 127);
		button6.Name = "button6";
		button6.Size = new System.Drawing.Size(189, 25);
		button6.TabIndex = 10;
		button6.Text = "Add";
		button6.UseVisualStyleBackColor = true;
		button6.Click += new System.EventHandler(Button6_Click);
		label7.AutoSize = true;
		label7.Location = new System.Drawing.Point(7, 77);
		label7.Name = "label7";
		label7.Size = new System.Drawing.Size(47, 13);
		label7.TabIndex = 2;
		label7.Text = "Duration";
		label6.AutoSize = true;
		label6.Location = new System.Drawing.Point(7, 50);
		label6.Name = "label6";
		label6.Size = new System.Drawing.Size(46, 13);
		label6.TabIndex = 1;
		label6.Text = "Amplifler";
		label5.AutoSize = true;
		label5.Location = new System.Drawing.Point(9, 23);
		label5.Name = "label5";
		label5.Size = new System.Drawing.Size(18, 13);
		label5.TabIndex = 0;
		label5.Text = "ID";
		groupBox5.Controls.Add(numericUpDown11);
		groupBox5.Controls.Add(numericUpDown9);
		groupBox5.Controls.Add(textBox1);
		groupBox5.Controls.Add(label11);
		groupBox5.Controls.Add(panel1);
		groupBox5.Controls.Add(numericUpDown10);
		groupBox5.Controls.Add(label10);
		groupBox5.Controls.Add(label9);
		groupBox5.Controls.Add(label8);
		groupBox5.Controls.Add(numericUpDown8);
		groupBox5.Controls.Add(checkBox8);
		groupBox5.Controls.Add(checkBox7);
		groupBox5.Controls.Add(checkBox6);
		groupBox5.Enabled = false;
		groupBox5.Location = new System.Drawing.Point(619, 13);
		groupBox5.Name = "groupBox5";
		groupBox5.Size = new System.Drawing.Size(156, 323);
		groupBox5.TabIndex = 10;
		groupBox5.TabStop = false;
		groupBox5.Text = "Color settings";
		numericUpDown11.Location = new System.Drawing.Point(-140, 207);
		numericUpDown11.Maximum = new decimal(new int[4]
		{
			64,
			0,
			0,
			0
		});
		numericUpDown11.Name = "numericUpDown11";
		numericUpDown11.Size = new System.Drawing.Size(134, 20);
		numericUpDown11.TabIndex = 17;
		numericUpDown9.Location = new System.Drawing.Point(87, 116);
		numericUpDown9.Maximum = new decimal(new int[4]
		{
			255,
			0,
			0,
			0
		});
		numericUpDown9.Name = "numericUpDown9";
		numericUpDown9.Size = new System.Drawing.Size(63, 20);
		numericUpDown9.TabIndex = 7;
		numericUpDown9.ValueChanged += new System.EventHandler(NumericUpDown9_ValueChanged);
		textBox1.Location = new System.Drawing.Point(6, 182);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(116, 20);
		textBox1.TabIndex = 13;
		label11.AutoSize = true;
		label11.Location = new System.Drawing.Point(5, 165);
		label11.Name = "label11";
		label11.Size = new System.Drawing.Size(57, 13);
		label11.TabIndex = 9;
		label11.Text = "Html value";
		panel1.BackColor = System.Drawing.Color.Black;
		panel1.Location = new System.Drawing.Point(6, 209);
		panel1.Name = "panel1";
		panel1.Size = new System.Drawing.Size(116, 108);
		panel1.TabIndex = 8;
		numericUpDown10.Location = new System.Drawing.Point(87, 143);
		numericUpDown10.Maximum = new decimal(new int[4]
		{
			255,
			0,
			0,
			0
		});
		numericUpDown10.Name = "numericUpDown10";
		numericUpDown10.Size = new System.Drawing.Size(63, 20);
		numericUpDown10.TabIndex = 7;
		numericUpDown10.ValueChanged += new System.EventHandler(NumericUpDown10_ValueChanged);
		label10.AutoSize = true;
		label10.Location = new System.Drawing.Point(5, 118);
		label10.Name = "label10";
		label10.Size = new System.Drawing.Size(36, 13);
		label10.TabIndex = 6;
		label10.Text = "Green";
		label9.AutoSize = true;
		label9.Location = new System.Drawing.Point(5, 145);
		label9.Name = "label9";
		label9.Size = new System.Drawing.Size(28, 13);
		label9.TabIndex = 5;
		label9.Text = "Blue";
		label8.AutoSize = true;
		label8.Location = new System.Drawing.Point(5, 90);
		label8.Name = "label8";
		label8.Size = new System.Drawing.Size(27, 13);
		label8.TabIndex = 4;
		label8.Text = "Red";
		numericUpDown8.Location = new System.Drawing.Point(87, 88);
		numericUpDown8.Maximum = new decimal(new int[4]
		{
			255,
			0,
			0,
			0
		});
		numericUpDown8.Name = "numericUpDown8";
		numericUpDown8.Size = new System.Drawing.Size(63, 20);
		numericUpDown8.TabIndex = 3;
		numericUpDown8.ValueChanged += new System.EventHandler(NumericUpDown8_ValueChanged);
		checkBox8.AutoSize = true;
		checkBox8.Enabled = false;
		checkBox8.Location = new System.Drawing.Point(7, 67);
		checkBox8.Name = "checkBox8";
		checkBox8.Size = new System.Drawing.Size(78, 17);
		checkBox8.TabIndex = 2;
		checkBox8.Text = "Undecided";
		checkBox8.UseVisualStyleBackColor = true;
		checkBox7.AutoSize = true;
		checkBox7.Location = new System.Drawing.Point(7, 43);
		checkBox7.Name = "checkBox7";
		checkBox7.Size = new System.Drawing.Size(80, 17);
		checkBox7.TabIndex = 1;
		checkBox7.Text = "Armor Color";
		checkBox7.UseVisualStyleBackColor = true;
		checkBox7.CheckedChanged += new System.EventHandler(CheckBox7_CheckedChanged);
		checkBox6.AutoSize = true;
		checkBox6.Location = new System.Drawing.Point(7, 20);
		checkBox6.Name = "checkBox6";
		checkBox6.Size = new System.Drawing.Size(74, 17);
		checkBox6.TabIndex = 0;
		checkBox6.Text = "Map Color";
		checkBox6.UseVisualStyleBackColor = true;
		checkBox6.CheckedChanged += new System.EventHandler(CheckBox6_CheckedChanged);
		numericUpDown15.Location = new System.Drawing.Point(113, 143);
		numericUpDown15.Maximum = new decimal(new int[4]
		{
			255,
			0,
			0,
			0
		});
		numericUpDown15.Name = "numericUpDown15";
		numericUpDown15.Size = new System.Drawing.Size(53, 20);
		numericUpDown15.TabIndex = 17;
		numericUpDown15.ValueChanged += new System.EventHandler(numericUpDown15_ValueChanged);
		numericUpDown12.Location = new System.Drawing.Point(85, 58);
		numericUpDown12.Name = "numericUpDown12";
		numericUpDown12.Size = new System.Drawing.Size(81, 20);
		numericUpDown12.TabIndex = 17;
		numericUpDown12.Value = new decimal(new int[4]
		{
			1,
			0,
			0,
			0
		});
		button7.Location = new System.Drawing.Point(87, 456);
		button7.Name = "button7";
		button7.Size = new System.Drawing.Size(171, 30);
		button7.TabIndex = 11;
		button7.Text = "The creator's Youtube channel";
		button7.UseVisualStyleBackColor = true;
		button7.Click += new System.EventHandler(Button7_Click);
		button8.Location = new System.Drawing.Point(264, 456);
		button8.Name = "button8";
		button8.Size = new System.Drawing.Size(171, 30);
		button8.TabIndex = 12;
		button8.Text = "The translator's Youtube channel";
		button8.UseVisualStyleBackColor = true;
		button8.Click += new System.EventHandler(Button8_Click);
		label12.AutoSize = true;
		label12.Location = new System.Drawing.Point(10, 467);
		label12.Name = "label12";
		label12.Size = new System.Drawing.Size(40, 13);
		label12.TabIndex = 13;
		label12.Text = "2.0.0.0";
		label13.AutoSize = true;
		label13.Location = new System.Drawing.Point(53, 467);
		label13.Name = "label13";
		label13.Size = new System.Drawing.Size(13, 13);
		label13.TabIndex = 14;
		label13.Text = "3";
		label13.Visible = false;
		comboBox1.FormattingEnabled = true;
		comboBox1.Items.AddRange(new object[6]
		{
			"Building block",
			"Decoration",
			"Material",
			"Food",
			"Tools, weapons, armor",
			"Other"
		});
		comboBox1.Location = new System.Drawing.Point(7, 31);
		comboBox1.Name = "comboBox1";
		comboBox1.Size = new System.Drawing.Size(159, 21);
		comboBox1.TabIndex = 15;
		comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		groupBox6.Controls.Add(numericUpDown15);
		groupBox6.Controls.Add(label17);
		groupBox6.Controls.Add(numericUpDown14);
		groupBox6.Controls.Add(label16);
		groupBox6.Controls.Add(numericUpDown13);
		groupBox6.Controls.Add(label15);
		groupBox6.Controls.Add(numericUpDown12);
		groupBox6.Controls.Add(label14);
		groupBox6.Controls.Add(comboBox1);
		groupBox6.Location = new System.Drawing.Point(441, 163);
		groupBox6.Name = "groupBox6";
		groupBox6.Size = new System.Drawing.Size(172, 173);
		groupBox6.TabIndex = 16;
		groupBox6.TabStop = false;
		groupBox6.Text = "Place to be placed in the creative section";
		label17.AutoSize = true;
		label17.Location = new System.Drawing.Point(6, 145);
		label17.Name = "label17";
		label17.Size = new System.Drawing.Size(44, 13);
		label17.TabIndex = 21;
		label17.Text = "Number";
		numericUpDown14.Location = new System.Drawing.Point(113, 116);
		numericUpDown14.Maximum = new decimal(new int[4]
		{
			2267,
			0,
			0,
			0
		});
		numericUpDown14.Name = "numericUpDown14";
		numericUpDown14.Size = new System.Drawing.Size(53, 20);
		numericUpDown14.TabIndex = 17;
		label16.AutoSize = true;
		label16.Location = new System.Drawing.Point(4, 118);
		label16.Name = "label16";
		label16.Size = new System.Drawing.Size(77, 13);
		label16.TabIndex = 20;
		label16.Text = "Damaged area";
		numericUpDown13.Location = new System.Drawing.Point(113, 87);
		numericUpDown13.Maximum = new decimal(new int[4]
		{
			2147483647,
			0,
			0,
			0
		});
		numericUpDown13.Name = "numericUpDown13";
		numericUpDown13.Size = new System.Drawing.Size(53, 20);
		numericUpDown13.TabIndex = 19;
		label15.AutoSize = true;
		label15.Location = new System.Drawing.Point(5, 89);
		label15.Name = "label15";
		label15.Size = new System.Drawing.Size(41, 13);
		label15.TabIndex = 18;
		label15.Text = "Item ID";
		label15.Click += new System.EventHandler(Label15_Click);
		label14.AutoSize = true;
		label14.Location = new System.Drawing.Point(5, 60);
		label14.Name = "label14";
		label14.Size = new System.Drawing.Size(34, 13);
		label14.TabIndex = 16;
		label14.Text = "Place";
		button9.Location = new System.Drawing.Point(441, 342);
		button9.Name = "button9";
		button9.Size = new System.Drawing.Size(334, 25);
		button9.TabIndex = 17;
		button9.Text = "Item ID list";
		button9.UseVisualStyleBackColor = true;
		button9.Click += new System.EventHandler(Button9_Click);
		button10.Location = new System.Drawing.Point(441, 375);
		button10.Name = "button10";
		button10.Size = new System.Drawing.Size(334, 25);
		button10.TabIndex = 18;
		button10.Text = "Enchant ID list";
		button10.UseVisualStyleBackColor = true;
		button10.Click += new System.EventHandler(Button10_Click);
		button11.Location = new System.Drawing.Point(441, 406);
		button11.Name = "button11";
		button11.Size = new System.Drawing.Size(334, 25);
		button11.TabIndex = 19;
		button11.Text = "Potion ID list";
		button11.UseVisualStyleBackColor = true;
		button11.Click += new System.EventHandler(Button11_Click);
		button12.Font = new System.Drawing.Font("MS UI Gothic", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
		button12.Location = new System.Drawing.Point(442, 438);
		button12.Name = "button12";
		button12.Size = new System.Drawing.Size(333, 48);
		button12.TabIndex = 20;
		button12.Text = "Terms of service";
		button12.UseVisualStyleBackColor = true;
		button12.Click += new System.EventHandler(Button12_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		AutoSize = true;
		AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
		base.ClientSize = new System.Drawing.Size(1006, 488);
		base.Controls.Add(button12);
		base.Controls.Add(button11);
		base.Controls.Add(button10);
		base.Controls.Add(button9);
		base.Controls.Add(groupBox6);
		base.Controls.Add(label13);
		base.Controls.Add(label12);
		base.Controls.Add(button8);
		base.Controls.Add(button7);
		base.Controls.Add(groupBox5);
		base.Controls.Add(groupBox4);
		base.Controls.Add(groupBox3);
		base.Controls.Add(button4);
		base.Controls.Add(button3);
		base.Controls.Add(richTextBox1);
		base.Controls.Add(groupBox2);
		base.Controls.Add(button2);
		base.Controls.Add(groupBox1);
		base.MaximizeBox = false;
		base.Name = "Form1";
		Text = "NBT tag code maker by 少年革命家のんちゃんチャンネル and translated by nt games";
		base.Load += new System.EventHandler(Form1_Load);
		((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
		groupBox1.ResumeLayout(false);
		groupBox1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
		groupBox2.ResumeLayout(false);
		groupBox2.PerformLayout();
		groupBox3.ResumeLayout(false);
		groupBox3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
		groupBox4.ResumeLayout(false);
		groupBox4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
		groupBox5.ResumeLayout(false);
		groupBox5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown15).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
		groupBox6.ResumeLayout(false);
		groupBox6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)numericUpDown14).EndInit();
		((System.ComponentModel.ISupportInitialize)numericUpDown13).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
