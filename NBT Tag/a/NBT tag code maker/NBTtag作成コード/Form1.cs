using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NBTtag作成コ\u30FCド
{
	// Token: 0x02000004 RID: 4
	public partial class Form1 : Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x000020FA File Offset: 0x000002FA
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002114 File Offset: 0x00000314
		private static string hexvalue(int Itemhexvalue)
		{
			bool flag = Itemhexvalue < 0;
			bool flag9 = flag;
			string result;
			if (flag9)
			{
				result = Convert.ToString(Itemhexvalue, 16);
			}
			else
			{
				bool flag2 = Itemhexvalue < 16;
				bool flag10 = flag2;
				if (flag10)
				{
					result = "0000000" + Convert.ToString(Itemhexvalue, 16);
				}
				else
				{
					bool flag3 = Itemhexvalue < 256;
					bool flag11 = flag3;
					if (flag11)
					{
						result = "000000" + Convert.ToString(Itemhexvalue, 16);
					}
					else
					{
						bool flag4 = Itemhexvalue < 4096;
						bool flag12 = flag4;
						if (flag12)
						{
							result = "00000" + Convert.ToString(Itemhexvalue, 16);
						}
						else
						{
							bool flag5 = Itemhexvalue < 65536;
							bool flag13 = flag5;
							if (flag13)
							{
								result = "0000" + Convert.ToString(Itemhexvalue, 16);
							}
							else
							{
								bool flag6 = Itemhexvalue < 1048576;
								bool flag14 = flag6;
								if (flag14)
								{
									result = "000" + Convert.ToString(Itemhexvalue, 16);
								}
								else
								{
									bool flag7 = Itemhexvalue < 16777216;
									bool flag15 = flag7;
									if (flag15)
									{
										result = "00" + Convert.ToString(Itemhexvalue, 16);
									}
									else
									{
										bool flag8 = Itemhexvalue < 268435456;
										bool flag16 = flag8;
										if (flag16)
										{
											result = "0" + Convert.ToString(Itemhexvalue, 16);
										}
										else
										{
											result = (Convert.ToString(Itemhexvalue, 16) ?? "");
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000228C File Offset: 0x0000048C
		private void Form1_Load(object sender, EventArgs e)
		{
			int red = (int)this.numericUpDown8.Value;
			int green = (int)this.numericUpDown9.Value;
			int blue = (int)this.numericUpDown10.Value;
			Color color = Color.FromArgb(red, green, blue);
			this.panel1.BackColor = color;
			string text = ColorTranslator.ToHtml(color);
			this.textBox1.Text = text;
			this.listView1.View = View.Details;
			this.listView1.Columns.Add("ID");
			this.listView1.Columns.Add("lvl");
			this.listView2.View = View.Details;
			this.listView2.Columns.Add("ID");
			this.listView2.Columns.Add("Amount");
			this.listView3.View = View.Details;
			this.listView3.Columns.Add("ID");
			this.listView3.Columns.Add("Amplifler");
			this.listView3.Columns.Add("Duration");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000023BA File Offset: 0x000005BA
		private void Button3_Click(object sender, EventArgs e)
		{
			this.richTextBox1.ResetText();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023CC File Offset: 0x000005CC
		private void Button4_Click(object sender, EventArgs e)
		{
			bool flag = this.richTextBox1.Text.Length == 0;
			bool flag2 = flag;
			if (flag2)
			{
				MessageBox.Show("error");
			}
			else
			{
				Clipboard.SetText(this.richTextBox1.Text);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002418 File Offset: 0x00000618
		private void NumericUpDown8_ValueChanged(object sender, EventArgs e)
		{
			int red = (int)this.numericUpDown8.Value;
			int green = (int)this.numericUpDown9.Value;
			int blue = (int)this.numericUpDown10.Value;
			Color color = Color.FromArgb(red, green, blue);
			this.panel1.BackColor = color;
			string text = ColorTranslator.ToHtml(color);
			this.textBox1.Text = text;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002488 File Offset: 0x00000688
		private void NumericUpDown9_ValueChanged(object sender, EventArgs e)
		{
			int red = (int)this.numericUpDown8.Value;
			int green = (int)this.numericUpDown9.Value;
			int blue = (int)this.numericUpDown10.Value;
			Color color = Color.FromArgb(red, green, blue);
			this.panel1.BackColor = color;
			string text = ColorTranslator.ToHtml(color);
			this.textBox1.Text = text;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000024F8 File Offset: 0x000006F8
		private void NumericUpDown10_ValueChanged(object sender, EventArgs e)
		{
			int red = (int)this.numericUpDown8.Value;
			int green = (int)this.numericUpDown9.Value;
			int blue = (int)this.numericUpDown10.Value;
			Color color = Color.FromArgb(red, green, blue);
			this.panel1.BackColor = color;
			string text = ColorTranslator.ToHtml(color);
			this.textBox1.Text = text;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002568 File Offset: 0x00000768
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox1.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.groupBox1.Enabled = false;
			}
			else
			{
				this.groupBox1.Enabled = true;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000025AC File Offset: 0x000007AC
		private void CheckBox3_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox3.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.groupBox4.Enabled = false;
			}
			else
			{
				this.groupBox4.Enabled = true;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000025EE File Offset: 0x000007EE
		private void GroupBox2_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000025F4 File Offset: 0x000007F4
		private void CheckBox5_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox5.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.groupBox5.Enabled = false;
			}
			else
			{
				this.groupBox5.Enabled = true;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002636 File Offset: 0x00000836
		private void Button7_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCXRPjFwZ_IBuRsbiJ5GlXdg/feed");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002644 File Offset: 0x00000844
		private void Button8_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.youtube.com/channel/UCqI3x47OlUfndU3b9VhAwwQ?view_as=subscriber");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002654 File Offset: 0x00000854
		private void CheckBox6_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox6.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.checkBox7.Enabled = true;
			}
			else
			{
				this.checkBox7.Enabled = false;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002698 File Offset: 0x00000898
		private void CheckBox7_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox7.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.checkBox6.Enabled = true;
			}
			else
			{
				this.checkBox6.Enabled = false;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000026DC File Offset: 0x000008DC
		private void Button2_Click(object sender, EventArgs e)
		{
			this.richTextBox1.ResetText();
			int num = 301989888;
			string text = " ";
			int red = (int)this.numericUpDown8.Value;
			int green = (int)this.numericUpDown9.Value;
			int blue = (int)this.numericUpDown10.Value;
			Color c = Color.FromArgb(red, green, blue);
			string text2 = ColorTranslator.ToHtml(c);
			bool @checked = this.checkBox1.Checked;
			bool flag23 = @checked;
			if (flag23)
			{
				bool flag = this.listView1.CheckedItems.Count == 0;
				bool flag24 = flag;
				if (flag24)
				{
					MessageBox.Show("Check the enchantment listView");
					return;
				}
				bool flag2 = this.listView1.CheckedItems.Count > 30;
				bool flag25 = flag2;
				if (flag25)
				{
					MessageBox.Show("Enchant listView has too many checks" + Environment.NewLine + "The maximum number is 30");
					return;
				}
			}
			else
			{
				bool checked2 = this.checkBox2.Checked;
				bool flag26 = checked2;
				if (flag26)
				{
					bool flag3 = this.listView2.CheckedItems.Count == 0;
					bool flag27 = flag3;
					if (flag27)
					{
						MessageBox.Show("Please check the listView of the potion");
						return;
					}
					bool flag4 = this.listView2.CheckedItems.Count > 30;
					bool flag28 = flag4;
					if (flag28)
					{
						MessageBox.Show("Too many checks in potion listView" + Environment.NewLine + "The maximum number is 30");
						return;
					}
				}
				else
				{
					bool checked3 = this.checkBox3.Checked;
					bool flag29 = checked3;
					if (flag29)
					{
						bool flag5 = this.listView3.CheckedItems.Count == 0;
						bool flag30 = flag5;
						if (flag30)
						{
							MessageBox.Show("Check the status listView");
							return;
						}
						bool flag6 = this.listView3.CheckedItems.Count > 30;
						bool flag31 = flag6;
						if (flag31)
						{
							MessageBox.Show("Too many checks in listView for status" + Environment.NewLine + "The maximum number is 30");
							return;
						}
					}
					else
					{
						bool checked4 = this.checkBox4.Checked;
						bool flag32 = !checked4;
						if (flag32)
						{
							bool checked5 = this.checkBox5.Checked;
							bool flag33 = !checked5;
							if (flag33)
							{
								MessageBox.Show("error");
								return;
							}
							bool flag7 = !this.checkBox6.Checked;
							bool flag34 = flag7;
							if (flag34)
							{
								bool flag8 = !this.checkBox7.Checked;
								bool flag35 = flag8;
								if (flag35)
								{
									this.richTextBox1.ResetText();
									MessageBox.Show("Check Map Color or Armor Color");
									return;
								}
							}
						}
					}
				}
			}
			bool flag9 = this.comboBox1.SelectedIndex == 0;
			bool flag36 = flag9;
			if (flag36)
			{
				text = "10a0a6c0";
			}
			else
			{
				bool flag10 = this.comboBox1.SelectedIndex == 1;
				bool flag37 = flag10;
				if (flag37)
				{
					text = "10a0a6d0";
				}
				else
				{
					bool flag11 = this.comboBox1.SelectedIndex == 2;
					bool flag38 = flag11;
					if (flag38)
					{
						text = "10a0a700";
					}
					else
					{
						bool flag12 = this.comboBox1.SelectedIndex == 3;
						bool flag39 = flag12;
						if (flag39)
						{
							text = "10a0a710";
						}
						else
						{
							bool flag13 = this.comboBox1.SelectedIndex == 4;
							bool flag40 = flag13;
							if (flag40)
							{
								text = "10a0a720";
							}
							else
							{
								bool flag14 = this.comboBox1.SelectedIndex == 5;
								bool flag41 = flag14;
								if (flag41)
								{
									text = "10a0a770";
								}
								else
								{
									bool flag15 = this.comboBox1.SelectedIndex == -1;
									bool flag42 = flag15;
									if (flag42)
									{
										MessageBox.Show("Please select the place to install in the creative column");
										return;
									}
								}
							}
						}
					}
				}
			}
			string text3 = Form1.hexvalue((int)this.numericUpDown13.Value * 4);
			string text4 = Form1.hexvalue((int)this.numericUpDown12.Value * 4);
			string text5 = Form1.hexvalue((int)this.numericUpDown15.Value);
			string text6 = Form1.hexvalue((int)this.numericUpDown14.Value);
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"30000000 109df84c",
				Environment.NewLine,
				"10000000 50000000",
				Environment.NewLine,
				"10120001 ",
				text3,
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"30000000 ",
				text,
				Environment.NewLine,
				"10000000 50000000",
				Environment.NewLine,
				"31000000 ",
				text4,
				Environment.NewLine,
				"30100000 00000000",
				Environment.NewLine,
				"10000000 50000000",
				Environment.NewLine,
				"11120001 00000014",
				Environment.NewLine,
				"0012000c ",
				text5,
				Environment.NewLine,
				"00120020 ",
				text6,
				Environment.NewLine,
				"00120018 ",
				Convert.ToString(num, 16),
				Environment.NewLine,
				"d0000000 deadcafe",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"0100001c ",
				Convert.ToString(num, 16),
				Environment.NewLine,
				"1058fa54 00a8a598",
				Environment.NewLine,
				"00000011 00000001",
				Environment.NewLine,
				"3f800000 00000011",
				Environment.NewLine,
				Convert.ToString(num + 48, 16),
				" 000000FF",
				Environment.NewLine,
				"30000000 ",
				Convert.ToString(num + 24, 16),
				Environment.NewLine,
				"10000000 50000000",
				Environment.NewLine,
				"00120044 ",
				Convert.ToString(num + 212, 16),
				Environment.NewLine,
				"01000044 ",
				Convert.ToString(num + 160, 16),
				Environment.NewLine,
				"1056415C "
			});
			bool checked6 = this.checkBox4.Checked;
			bool flag43 = checked6;
			if (flag43)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"01000000",
					Environment.NewLine,
					"00000000 00000000",
					Environment.NewLine
				});
			}
			else
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"00000000",
					Environment.NewLine,
					"00000000 00000000",
					Environment.NewLine
				});
			}
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"11B0D430 0000afb8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 224, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 160, 16),
				" ",
				Convert.ToString(num + 308, 16),
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine,
				"01000018 ",
				Convert.ToString(num + 224, 16),
				Environment.NewLine,
				"0055006E 00620072",
				Environment.NewLine,
				"00650061 006B0061",
				Environment.NewLine,
				"0062006C 00650000",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000030 ",
				Convert.ToString(num + 272, 16),
				Environment.NewLine,
				"11B0D430 0000AFB8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 320, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 4096, 16),
				" ",
				Convert.ToString(num + 388, 16),
				Environment.NewLine,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000014 ",
				Convert.ToString(num + 320, 16),
				Environment.NewLine,
				"00640069 00730070",
				Environment.NewLine,
				"006C0061 00790000",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"0100001c ",
				Convert.ToString(num + 4096, 16),
				Environment.NewLine,
				"1058fa54 00a8a598",
				Environment.NewLine,
				"00000011 00000001",
				Environment.NewLine,
				"3f800000 00000011",
				Environment.NewLine,
				Convert.ToString(num + 48 + 4096, 16),
				" 000000FF",
				Environment.NewLine,
				"30000000 ",
				Convert.ToString(num + 24 + 4096, 16),
				Environment.NewLine,
				"10000000 50000000",
				Environment.NewLine,
				"00120044 ",
				Convert.ToString(num + 212 + 4096, 16),
				Environment.NewLine,
				"01000044 ",
				Convert.ToString(num + 160 + 4096, 16),
				Environment.NewLine,
				"1065993C 00",
				text2.Substring(1, 6),
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"11B0D430 0000afb8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 224 + 4096, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 160 + 4096, 16),
				" 00000000",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			bool checked7 = this.checkBox7.Checked;
			bool flag44 = checked7;
			if (flag44)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100000c ",
					Convert.ToString(num + 224 + 4096, 16),
					Environment.NewLine,
					"0063006F 006C006F",
					Environment.NewLine,
					"00720000 000000ff",
					Environment.NewLine
				});
			}
			bool checked8 = this.checkBox6.Checked;
			bool flag45 = checked8;
			if (flag45)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"01000014 ",
					Convert.ToString(num + 224 + 4096, 16),
					Environment.NewLine,
					"004D0061 00700043",
					Environment.NewLine,
					"006F006C 006F0072",
					Environment.NewLine,
					"00000000 000000ff",
					Environment.NewLine
				});
			}
			bool flag16 = !this.checkBox5.Checked;
			bool flag46 = flag16;
			if (flag46)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"01000016 ",
					Convert.ToString(num + 224 + 4096, 16),
					Environment.NewLine,
					"00000000 00000000",
					Environment.NewLine,
					"00000000 00000000",
					Environment.NewLine,
					"00000000 000000ff",
					Environment.NewLine
				});
			}
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000030 ",
				Convert.ToString(num + 352, 16),
				Environment.NewLine,
				"11B0D430 0000AFB8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 400, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 8192, 16),
				" ",
				Convert.ToString(num + 468, 16),
				Environment.NewLine,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000014 ",
				Convert.ToString(num + 400, 16),
				Environment.NewLine,
				"0065006E 00630068",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000030 ",
				Convert.ToString(num + 432, 16),
				Environment.NewLine,
				"11B0D430 0000AFB8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 480, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 20480, 16),
				" ",
				Convert.ToString(num + 596, 16),
				Environment.NewLine,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000026 ",
				Convert.ToString(num + 480, 16),
				Environment.NewLine,
				"00410074 00740072",
				Environment.NewLine,
				"00690062 00750074",
				Environment.NewLine,
				"0065004D 006F0064",
				Environment.NewLine,
				"00690066 00690065",
				Environment.NewLine,
				"00720073 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"01000030 ",
				Convert.ToString(num + 560, 16),
				Environment.NewLine,
				"11B0D430 0000AFB8",
				Environment.NewLine,
				"00000000 00000000",
				Environment.NewLine,
				"11B0D430 ",
				Convert.ToString(num + 608, 16),
				Environment.NewLine,
				"00000000 00000017",
				Environment.NewLine,
				Convert.ToString(num + 40960, 16),
				" 00000000",
				Environment.NewLine,
				"00000000 0000003b",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			this.richTextBox1.Text = string.Concat(new string[]
			{
				this.richTextBox1.Text,
				"0100002c ",
				Convert.ToString(num + 608, 16),
				Environment.NewLine,
				"00430075 00730074",
				Environment.NewLine,
				"006F006D 0050006F",
				Environment.NewLine,
				"00740069 006F006E",
				Environment.NewLine,
				"00450066 00660065",
				Environment.NewLine,
				"00630074 00730000",
				Environment.NewLine,
				"00000000 000000ff",
				Environment.NewLine
			});
			bool checked9 = this.checkBox1.Checked;
			bool flag47 = checked9;
			if (flag47)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100001c ",
					Convert.ToString(num + 8192, 16),
					Environment.NewLine,
					"1067DAF0 00000000",
					Environment.NewLine,
					Convert.ToString(num + 8240, 16),
					" ",
					Convert.ToString(num + 8240 + this.listView1.CheckedItems.Count * 4, 16),
					Environment.NewLine,
					Convert.ToString(num + 8240 + this.listView1.CheckedItems.Count * 4, 16),
					" 0A000000",
					Environment.NewLine,
					"00000000 000000FF",
					Environment.NewLine
				});
				int i = 0;
				int num2 = 0;
				int num3 = 0;
				string text7 = "";
				while (i < this.listView1.Items.Count)
				{
					bool checked10 = this.listView1.Items[i].Checked;
					bool flag48 = checked10;
					if (flag48)
					{
						bool flag17 = num2 % 2 == 0;
						bool flag49 = flag17;
						if (flag49)
						{
							text7 = text7 + Convert.ToString(num + 8496 + num2 * 320, 16) + " ";
						}
						else
						{
							text7 = text7 + Convert.ToString(num + 8496 + num2 * 320, 16) + Environment.NewLine;
						}
						string text8 = Form1.hexvalue(int.Parse(this.listView1.Items[i].SubItems[1].Text));
						string text9 = Form1.hexvalue(int.Parse(this.listView1.Items[i].SubItems[0].Text));
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100001c ",
							Convert.ToString(num + 8496 + num3, 16),
							Environment.NewLine,
							"1058fa54 00a8a598",
							Environment.NewLine,
							"00000011 00000001",
							Environment.NewLine,
							"3f800000 00000011",
							Environment.NewLine,
							Convert.ToString(num + 48 + 8496 + num3, 16),
							" 000000ff",
							Environment.NewLine,
							"30000000 ",
							Convert.ToString(num + 24 + 8496 + num3, 16),
							Environment.NewLine,
							"10000000 50000000",
							Environment.NewLine,
							"00120044 ",
							Convert.ToString(num + 212 + 8496 + num3, 16),
							Environment.NewLine,
							"01000044 ",
							Convert.ToString(num + 160 + 8496 + num3, 16),
							Environment.NewLine,
							"10748CF8 ",
							text8.Substring(4, 4),
							"0000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 8720 + num3, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 160 + 8496 + num3, 16),
							" ",
							Convert.ToString(num + 8788 + num3, 16),
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100000c ",
							Convert.ToString(num + 8720 + num3, 16),
							Environment.NewLine,
							"006C0076 006C0000",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000044 ",
							Convert.ToString(num + 8736 + num3, 16),
							Environment.NewLine,
							"10748CF8 ",
							text9.Substring(4, 4),
							"0000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 8800 + num3, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 8736 + num3, 16),
							" 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100000c ",
							Convert.ToString(num + 8800 + num3, 16),
							Environment.NewLine,
							"00690064 00000000",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						num3 += 320;
						num2++;
					}
					i++;
				}
				bool flag18 = num2 % 2 == 1;
				bool flag50 = flag18;
				if (flag50)
				{
					string text10 = Form1.hexvalue(this.listView1.CheckedItems.Count * 4 + 8);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text10.Substring(4, 4),
						" ",
						Convert.ToString(num + 8240, 16),
						Environment.NewLine,
						text7,
						"00000000",
						Environment.NewLine,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
				else
				{
					string text11 = Form1.hexvalue(this.listView1.CheckedItems.Count * 4 + 4);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text11.Substring(4, 4),
						" ",
						Convert.ToString(num + 8240, 16),
						Environment.NewLine,
						text7,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
			}
			else
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100000c ",
					Convert.ToString(num + 8192, 16),
					Environment.NewLine,
					"1065993C 00000000",
					Environment.NewLine,
					"00000000 000000ff",
					Environment.NewLine
				});
			}
			bool checked11 = this.checkBox2.Checked;
			bool flag51 = checked11;
			if (flag51)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100001c ",
					Convert.ToString(num + 20480, 16),
					Environment.NewLine,
					"1067DAF0 00000000",
					Environment.NewLine,
					Convert.ToString(num + 20528, 16),
					" ",
					Convert.ToString(num + 20528 + this.listView2.CheckedItems.Count * 4, 16),
					Environment.NewLine,
					Convert.ToString(num + 20528 + this.listView2.CheckedItems.Count * 4, 16),
					" 0A000000",
					Environment.NewLine,
					"00000000 000000FF",
					Environment.NewLine
				});
				int j = 0;
				int num4 = 0;
				int num5 = 0;
				string text12 = "";
				while (j < this.listView2.Items.Count)
				{
					bool checked12 = this.listView2.Items[j].Checked;
					bool flag52 = checked12;
					if (flag52)
					{
						bool flag19 = num4 % 2 == 0;
						bool flag53 = flag19;
						if (flag53)
						{
							text12 = text12 + Convert.ToString(num + 20784 + num4 * 336, 16) + " ";
						}
						else
						{
							text12 = text12 + Convert.ToString(num + 20784 + num4 * 336, 16) + Environment.NewLine;
						}
						string text13 = Form1.hexvalue(int.Parse(this.listView2.Items[j].SubItems[0].Text));
						double value = double.Parse(this.listView2.Items[j].SubItems[1].Text);
						byte[] bytes = BitConverter.GetBytes(value);
						string[] value2 = bytes.Select(delegate(byte a)
						{
							byte b = a;
							return b.ToString("X2");
						}).Reverse<string>().ToArray<string>();
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100001c ",
							Convert.ToString(num + 20784 + num5, 16),
							Environment.NewLine,
							"1058fa54 00a8a598",
							Environment.NewLine,
							"00000011 00000001",
							Environment.NewLine,
							"3f800000 00000011",
							Environment.NewLine,
							Convert.ToString(num + 48 + 20784 + num5, 16),
							" 000000ff",
							Environment.NewLine,
							"30000000 ",
							Convert.ToString(num + 24 + 20784 + num5, 16),
							Environment.NewLine,
							"10000000 50000000",
							Environment.NewLine,
							"00120044 ",
							Convert.ToString(num + 212 + 20784 + num5, 16),
							Environment.NewLine,
							"01000044 ",
							Convert.ToString(num + 160 + 20784 + num5, 16),
							Environment.NewLine,
							"1065993C ",
							text13,
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 21008 + num5, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 160 + 20784 + num5, 16),
							" ",
							Convert.ToString(num + 21076 + num5, 16),
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100000c ",
							Convert.ToString(num + 21008 + num5, 16),
							Environment.NewLine,
							"00490044 00000000",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000044 ",
							Convert.ToString(num + 21024 + num5, 16),
							Environment.NewLine,
							"105C76B4 00000000",
							Environment.NewLine,
							string.Join("", value2).Substring(0, 8),
							" 00000000",
							Environment.NewLine,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 21088 + num5, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 21024 + num5, 16),
							" 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100000e ",
							Convert.ToString(num + 21088 + num5, 16),
							Environment.NewLine,
							"0041006D 006F0075",
							Environment.NewLine,
							"006E0074 000000ff",
							Environment.NewLine
						});
						num5 += 336;
						num4++;
					}
					j++;
				}
				bool flag20 = num4 % 2 == 1;
				bool flag54 = flag20;
				if (flag54)
				{
					string text14 = Form1.hexvalue(this.listView2.CheckedItems.Count * 4 + 8);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text14.Substring(4, 4),
						" ",
						Convert.ToString(num + 20528, 16),
						Environment.NewLine,
						text12,
						"00000000",
						Environment.NewLine,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
				else
				{
					string text15 = Form1.hexvalue(this.listView2.CheckedItems.Count * 4 + 4);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text15.Substring(4, 4),
						" ",
						Convert.ToString(num + 20528, 16),
						Environment.NewLine,
						text12,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
			}
			else
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100000c ",
					Convert.ToString(num + 20480, 16),
					Environment.NewLine,
					"1065993C 00000000",
					Environment.NewLine,
					"00000000 000000ff",
					Environment.NewLine
				});
			}
			bool checked13 = this.checkBox3.Checked;
			bool flag55 = checked13;
			if (flag55)
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100001c ",
					Convert.ToString(num + 40960, 16),
					Environment.NewLine,
					"1067DAF0 00000000",
					Environment.NewLine,
					Convert.ToString(num + 41008, 16),
					" ",
					Convert.ToString(num + 41008 + this.listView3.CheckedItems.Count * 4, 16),
					Environment.NewLine,
					Convert.ToString(num + 41008 + this.listView3.CheckedItems.Count * 4, 16),
					" 0A000000",
					Environment.NewLine,
					"00000000 000000FF",
					Environment.NewLine
				});
				int k = 0;
				int num6 = 0;
				int num7 = 0;
				string text16 = "";
				while (k < this.listView3.Items.Count)
				{
					bool checked14 = this.listView3.Items[k].Checked;
					bool flag56 = checked14;
					if (flag56)
					{
						bool flag21 = num6 % 2 == 0;
						bool flag57 = flag21;
						if (flag57)
						{
							text16 = text16 + Convert.ToString(num + 41264 + num6 * 464, 16) + " ";
						}
						else
						{
							text16 = text16 + Convert.ToString(num + 41264 + num6 * 464, 16) + Environment.NewLine;
						}
						string text17 = Form1.hexvalue(int.Parse(this.listView3.Items[k].SubItems[1].Text));
						string text18 = Form1.hexvalue(int.Parse(this.listView3.Items[k].SubItems[0].Text));
						string text19 = Form1.hexvalue(int.Parse(this.listView3.Items[k].SubItems[2].Text));
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100001c ",
							Convert.ToString(num + 41264 + num7, 16),
							Environment.NewLine,
							"1058fa54 00a8a598",
							Environment.NewLine,
							"00000011 00000001",
							Environment.NewLine,
							"3f800000 00000011",
							Environment.NewLine,
							Convert.ToString(num + 41312 + num7, 16),
							" 000000ff",
							Environment.NewLine,
							"30000000 ",
							Convert.ToString(num + 24 + 41264 + num7, 16),
							Environment.NewLine,
							"10000000 50000000",
							Environment.NewLine,
							"00120044 ",
							Convert.ToString(num + 212 + 41264 + num7, 16),
							Environment.NewLine,
							"01000044 ",
							Convert.ToString(num + 160 + 41264 + num7, 16),
							Environment.NewLine,
							"1065993C ",
							text18,
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 41488 + num7, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 160 + 41264 + num7, 16),
							" ",
							Convert.ToString(num + 41556 + num7, 16),
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"0100000c ",
							Convert.ToString(num + 41488 + num7, 16),
							Environment.NewLine,
							"00490064 00000000",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000044 ",
							Convert.ToString(num + 41504 + num7, 16),
							Environment.NewLine,
							"1065993C ",
							text19,
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 41568 + num7, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 41504 + num7, 16),
							" ",
							Convert.ToString(num + 41668 + num7, 16),
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000014 ",
							Convert.ToString(num + 41568 + num7, 16),
							Environment.NewLine,
							"00440075 00720061",
							Environment.NewLine,
							"00740069 006F006E",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000044 ",
							Convert.ToString(num + 41616 + num7, 16),
							Environment.NewLine,
							"1065993C ",
							text17,
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 00000000",
							Environment.NewLine,
							"00000000 00000000",
							Environment.NewLine,
							"11B0D430 ",
							Convert.ToString(num + 41680 + num7, 16),
							Environment.NewLine,
							"00000000 00000017",
							Environment.NewLine,
							Convert.ToString(num + 41616 + num7, 16),
							" 00000000",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"00000000 0000003b",
							Environment.NewLine,
							"00000000 000000ff",
							Environment.NewLine
						});
						this.richTextBox1.Text = string.Concat(new string[]
						{
							this.richTextBox1.Text,
							"01000014 ",
							Convert.ToString(num + 41680 + num7, 16),
							Environment.NewLine,
							"0041006D 0070006C",
							Environment.NewLine,
							"00690066 00690065",
							Environment.NewLine,
							"00720000 000000ff",
							Environment.NewLine
						});
						num7 += 464;
						num6++;
					}
					k++;
				}
				bool flag22 = num6 % 2 == 1;
				bool flag58 = flag22;
				if (flag58)
				{
					string text20 = Form1.hexvalue(this.listView3.CheckedItems.Count * 4 + 8);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text20.Substring(4, 4),
						" ",
						Convert.ToString(num + 41008, 16),
						Environment.NewLine,
						text16,
						"00000000",
						Environment.NewLine,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
				else
				{
					string text21 = Form1.hexvalue(this.listView3.CheckedItems.Count * 4 + 4);
					this.richTextBox1.Text = string.Concat(new string[]
					{
						this.richTextBox1.Text,
						"0100",
						text21.Substring(4, 4),
						" ",
						Convert.ToString(num + 41008, 16),
						Environment.NewLine,
						text16,
						"00000000 000000ff",
						Environment.NewLine
					});
				}
			}
			else
			{
				this.richTextBox1.Text = string.Concat(new string[]
				{
					this.richTextBox1.Text,
					"0100000c ",
					Convert.ToString(num + 40960, 16),
					Environment.NewLine,
					"1065993C 00000000",
					Environment.NewLine,
					"00000000 000000ff",
					Environment.NewLine
				});
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000054A0 File Offset: 0x000036A0
		private void CheckBox2_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this.checkBox2.Checked;
			bool flag2 = flag;
			if (flag2)
			{
				this.groupBox3.Enabled = false;
			}
			else
			{
				this.groupBox3.Enabled = true;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000054E4 File Offset: 0x000036E4
		private void Button1_Click(object sender, EventArgs e)
		{
			ListViewItem listViewItem = this.listView1.Items.Add(this.numericUpDown1.Value.ToString());
			listViewItem.SubItems.Add(this.numericUpDown2.Value.ToString());
			this.listView1.CheckBoxes = true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00005544 File Offset: 0x00003744
		private void Button5_Click(object sender, EventArgs e)
		{
			ListViewItem listViewItem = this.listView2.Items.Add(this.numericUpDown3.Value.ToString());
			listViewItem.SubItems.Add(this.numericUpDown4.Value.ToString());
			this.listView2.CheckBoxes = true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000055A4 File Offset: 0x000037A4
		private void Button6_Click(object sender, EventArgs e)
		{
			ListViewItem listViewItem = this.listView3.Items.Add(this.numericUpDown5.Value.ToString());
			listViewItem.SubItems.Add(this.numericUpDown6.Value.ToString());
			listViewItem.SubItems.Add(this.numericUpDown7.Value.ToString());
			this.listView3.CheckBoxes = true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025EE File Offset: 0x000007EE
		private void Label15_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00005621 File Offset: 0x00003821
		private void Button9_Click(object sender, EventArgs e)
		{
			Process.Start("https://minecraft-ids.grahamedgecombe.com/");
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000562F File Offset: 0x0000382F
		private void Button10_Click(object sender, EventArgs e)
		{
			Process.Start("https://minecraft-ja.gamepedia.com/エンチャント/ID");
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000563D File Offset: 0x0000383D
		private void Button11_Click(object sender, EventArgs e)
		{
			Process.Start("https://minecraft-ja.gamepedia.com/ステータス効果/ID");
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000564B File Offset: 0x0000384B
		private void Button12_Click(object sender, EventArgs e)
		{
			MessageBox.Show("This is made by 少年革命家のんちゃんチャンネル and translated by nt games !\r\n\r\nDon't try to decompile or your PC will be hacked in the next 24 hours (same for your discord account).");
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000025EE File Offset: 0x000007EE
		private void numericUpDown15_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025EE File Offset: 0x000007EE
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}
	}
}
